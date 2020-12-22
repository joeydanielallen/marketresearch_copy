using afmr.data;
using afmr.data.Models;
using afmr.data.Models.Template;
using afmr.domain.Internal.Models.Odysseus;
using afmr.domain.Internal.Models.Sustainment.NSN;
using afmr.domain.Internal.Models.Sustainment.Vendors;
using afmr.domain.Mappers;
using afmr.domain.Security;
using afmr.model;
using afmr.model.Account;
using afmr.model.Research;
using afmr.model.Vendors;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using static afmr.domain.Mappers.Mapper;

namespace afmr.domain.Services
{
    public class ResearchService : ServiceBase, IResearchService
    {
        public ResearchService(
            model.ILogger logger,
            IUnitOfWork unitOfWork,
            IUserIdentity userIdentity,
            IConfig config)
            : base(logger, unitOfWork, userIdentity, config) { }

        public InitiateResponse Initiate(InitiateRequest request)
        {
            if(null == request)
            {
                throw new ArgumentNullException(nameof(request));
            }

            var nsnToFind = request.Nsn.Substring(0, 13);
            var response = new InitiateResponse();

            var moeAndPartsTask = GetApiClient(false).GetAsync(_config.SustainmentApiNsnSearchUrl + nsnToFind);
            var suggestVendorsTask = GetApiClient(false).GetAsync(_config.SustainmentApiNsnToVendorUrl + nsnToFind);

            try
            {
                Task.WaitAll(moeAndPartsTask, suggestVendorsTask);
            }
            catch (AggregateException e)
            {
                _logger.LogError(e, "Error initiating research during API call");
                throw;
            }

            var apiData = GetTaskContent(moeAndPartsTask.Result.Content.ReadAsStringAsync());

            var nsnData = JsonConvert.DeserializeObject<GetNationalStockNumberResponse>(apiData);

            apiData = GetTaskContent(suggestVendorsTask.Result.Content.ReadAsStringAsync());

            var vendorSearchData = JsonConvert.DeserializeObject<VendorSearchByNsn>(apiData);

            var vendorSearch = vendorSearchData.Results
                .Take(50) //TODO drive from configuration, default to app config, later for org and/or profile
                .Map();

            MergeData(vendorSearch);

            SetInitiateSummary(response, request);

            if (nsnData.status == 200) //ProcessStatus.Complete)
            {
                SetProposedBidType(response, nsnData);

                SetVendorParts(response, nsnData);

                response.SuggestedVendors = vendorSearch;

                MaterialMgmtAggregateCode dataMmac = null;
                IEnumerable<data.Models.Template.TemplateInstance> priorResearchByNsn;
                IEnumerable<data.Models.Template.Template> possibleTemplates;

                using (_unitOfWork)
                {
                    dataMmac = request.Nsn.Length == 15 ? _unitOfWork.MaterialMgmtAggregateCodeRepo.GetMmac(request.Nsn.Substring(13, 2)) : null;
                    priorResearchByNsn = _unitOfWork.TemplateInstanceRepo.GetByNSN(nsnToFind);
                    possibleTemplates = _unitOfWork.TemplateRepo.GetActiveByOrg(_userIdentity.OrgIds);
                }

                response.ProposedTemplates = possibleTemplates
                    .SelectMany(e => 
                            e.MapToFormTemplate(
                                _userIdentity.OrgIds, 
                                (int)response.ProposedBidType, 
                                (int)request.ServiceType, 
                                (int)request.SourceType,
                                request.TotalEstimatedValue))
                    .ToList();

                var orgPossibleTemps = possibleTemplates
                        .Where(e => !response.ProposedTemplates.Select(e => e.Id).Contains(e.Id))
                        .ToList();

                response.RemainingTemplates = orgPossibleTemps
                        .SelectMany(e => 
                        e.MapToFormTemplate(
                            _userIdentity.OrgIds,
                            (int)response.ProposedBidType,
                            (int)request.ServiceType,
                            (int)request.SourceType,
                            request.TotalEstimatedValue, true))
                        .ToList();

                response.PriorResearchSummaries = priorResearchByNsn.Select(e => e.MapToSummary());

                response.InitiateNsn = new InitiateNsn()
                {
                    FscName = nsnData.FederalSupplyClass.Description,
                    FsgName = nsnData.FederalSupplyGroup.Description,                    
                    Mmac = dataMmac == null ? string.Empty : dataMmac.Code + " " + dataMmac.Description, 
                    Name = nsnData.Nomenclature,
                    Nsn = request.Nsn
                };
                
                response.ModelHash = Hasher.ComputeHash(JsonConvert.SerializeObject(response), _userIdentity.UserId.ToString());
                return response;

            }
            else
            {
                response.ProposedBidType = model.Research.BidType.Unknown;
                response.SearchQueueResponse = new SearchQueueResponse()
                {
                    ProcessMessage = "Error",
                    ProcessStatusDescription = "Error occurred during process. Status code " + nsnData.status.ToString()
                };
            }

            return response;
        }

        public StartResponse Start(StartResearchRequest request)
        {
            var response = new StartResponse();

            response.ValidationErrors = ValidateStart(request);

            if(response.ValidationErrors.Any())
            {
               return response;
            }

            response.TemplateInstanceId = CreateTemplateInstance(request);

            return response;
        }
        
        public IEnumerable<string> ValidateStart(StartResearchRequest request)
        {
            var validationErrors = new List<string>();

            if(request.FormTemplate == null)
            {
                validationErrors.Add(StartResearchValidation.FormTemplateNull);
                return validationErrors;
            }

            if (request.InitiateResponse == null)
            {
                validationErrors.Add(StartResearchValidation.InitiateResponseNull);
                return validationErrors;
            }

            //if (string.IsNullOrWhiteSpace(request.RemainingTemplateReason) && 
            //    request.InitiateResponse.RemainingTemplates
            //    .Select(e => e.Id)
            //    .Contains(request.FormTemplate.Id))
            //{
            //    validationErrors.Add(StartResearchValidation.NoUnsuggestedChoiceReason);
            //    return validationErrors;
            //}

            if(!_userIdentity.OrgIds.Contains(request.FormTemplate.OrgId))
            {
                validationErrors.Add(StartResearchValidation.InvalidUserOrgTemplate);
                return validationErrors;
            }

            var templateToUse = _unitOfWork.TemplateRepo.Get(request.FormTemplate.Id);
            if (null == templateToUse ||
                !templateToUse.IsActive)
            {
                validationErrors.Add(StartResearchValidation.TemplateIsNotActive);
                return validationErrors;
            }

            var hash = request.InitiateResponse.ModelHash;
            request.InitiateResponse.ModelHash = null;
            var currentHash = Hasher.ComputeHash(JsonConvert.SerializeObject(request.InitiateResponse), _userIdentity.UserId.ToString());
            if (hash != currentHash)
            {
//TODO uncomment and fix hash validation bug
                //validationErrors.Add(StartResearchValidation.InvalidInitiateHash);
                //return validationErrors;
            }

            return validationErrors.Any() ? validationErrors : null;
        }

        public model.Research.TemplateInstance Get(int id)
        {
            var instance = GetTemplateInstanceAndTemplate(id).Map();

            if(null == instance)
            {
                return null;
            }

           if(instance.Nsn.Length > 13)
            {
                var mmac = instance.Nsn.Substring(13);
                var data = _unitOfWork.MaterialMgmtAggregateCodeRepo.GetMmac(mmac);
                if(null != data)
                {
                    instance.Mmac = data.Code + ' ' + data.Description;
                }
            }

            //if no answers then create what we can to speed experience
            if(!instance.Answers.Any())
            {
                var answers = new List<model.Research.TemplateInstanceAnswer>();

                foreach (var tempSection in instance.Template.Sections)
                {
                    foreach (var question in tempSection.Questions)
                    {
                        if(!question.AllowMultipleSelectAnswers)
                        {
                            var answer = new model.Research.TemplateInstanceAnswer();
                            answer.TemplateSectionId = tempSection.Id;
                            answer.TemplateInstanceId = id;
                            answer.SectionQuestionId = question.Id;

                            answers.Add(answer);
                        }
                    }
                }

                instance.Answers = answers;
            }
            
            return instance;
        }

        public IEnumerable<TemplateInstanceSummary> GetSummaries(bool isInProgressOnly = false)
        {
            var summaries = new List<TemplateInstanceSummary>();

            using (_unitOfWork)
            {
                var tempInstances = isInProgressOnly ? _unitOfWork.TemplateInstanceRepo.GetInProgressForUser(_userIdentity.UserId) :
                    _unitOfWork.TemplateInstanceRepo.GetByUserId(_userIdentity.UserId);

                if(null != tempInstances && 
                    tempInstances.Any())
                {
                    foreach (var instance in tempInstances)
                    {
                        var summary = new TemplateInstanceSummary();
                        summary.AssignedUsers = instance.TemplateUsers.Select(e =>
                        {
                            var appUser = new AppUser();
                            appUser.FirstName = e.UserAccount.FirstName;
                            appUser.Id = e.UserAccountId;
                            appUser.LastName = e.UserAccount.LastName;
                            appUser.TemplateInstanceUserId = e.Id;

                            return appUser;
                        });
                        
                        summary.CompletedOnUtc = instance.CompletedOnUtc.HasValue ? instance.CompletedOnUtc.Value.ToUniversalTime() : (DateTime?)null;
                        summary.CreatedOnUtc = instance.CreatedOnUtc.ToUniversalTime();
                        summary.CreatedByAppUser = new AppUser();
                        summary.CreatedByAppUser.FirstName = instance.CreatedByUser.FirstName;
                        summary.CreatedByAppUser.LastName = instance.CreatedByUser.LastName;
                        summary.CreatedByAppUser.Id = instance.CreatedByUserAccountId;
                        summary.Id = instance.Id;
                        summary.Title = instance.Name;
                        summary.OriginalName = instance.OriginalTemplateName;

                        summaries.Add(summary);
                    }
                }
            }

            return summaries;
        }

        public void Delete(int templateInstanceId)
        {
            using (_unitOfWork)
            {
                var tempInstance = _unitOfWork.TemplateInstanceRepo.GetForDelete(templateInstanceId);

                if (null != tempInstance)
                {
                    if (tempInstance.CreatedByUserAccountId == _userIdentity.UserId)
                    {
                        if (!tempInstance.CompletedOnUtc.HasValue)
                        {
                            _unitOfWork.TemplateInstanceRepo.Delete(tempInstance);                            
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                "Completed template instance cannot be deleted");
                        }
                        _unitOfWork.Save();
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "User is not creator and does not have permission to delete");
                    }
                }
            }
        }

        public void ToggleComplete(int templateInstanceId)
        {
            using (_unitOfWork)
            {
                var tempInstance = _unitOfWork.TemplateInstanceRepo.Get(templateInstanceId, false);

                if(null != tempInstance)
                {
                    if (tempInstance.CreatedByUser.UserAccountId == _userIdentity.UserId)
                    {
                        if (tempInstance.CompletedOnUtc.HasValue)
                        {
                            tempInstance.CompletedOnUtc = null;
                        }
                        else
                        {
                            tempInstance.CompletedOnUtc = DateTime.UtcNow;
                        }
                        _unitOfWork.TemplateInstanceRepo.Update(tempInstance);
                        _unitOfWork.Save();
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "User is not creator and does not have permissions to complete");
                    } 
                }
            }
        }

        public void UpdateName(int templateInstanceId, string name)
        {
            using (_unitOfWork)
            {
                var tempInstance = _unitOfWork.TemplateInstanceRepo.Get(templateInstanceId, false);

                if (null != tempInstance)
                {
                    if (tempInstance.CreatedByUserAccountId == _userIdentity.UserId)
                    {
                        if (!tempInstance.CompletedOnUtc.HasValue)
                        {
                            tempInstance.CreatedByUser = null;
                            tempInstance.Name = name;
                            _unitOfWork.TemplateInstanceRepo.Update(tempInstance);
                        }
                        else
                        {
                            throw new InvalidOperationException(
                                "Completed template instance cannot be edited");
                        }
                        _unitOfWork.Save();
                    }
                    else
                    {
                        throw new InvalidOperationException(
                            "User is not creator and does not have permission to edit");
                    }
                }
            }
        }

        public IEnumerable<model.Research.TemplateInstanceUser> GetUsers(int templateInstanceId)
        {
            using (_unitOfWork)
            {
                var data = _unitOfWork.TemplateInstanceUserRepo.GetAll(templateInstanceId);

                return data
                    .Select(e =>
                    {
                        var user = new model.Research.TemplateInstanceUser();
                        user.FirstName = e.UserAccount.FirstName;
                        user.Id = e.Id;
                        user.LastName = e.UserAccount.LastName;
                        user.UserAccountId = e.UserAccountId;

                        return user;
                    });
            }
        }

        public void DeleteUser(int templateInstanceUserId)
        {
            using (_unitOfWork)
            {
                var user = _unitOfWork.TemplateInstanceUserRepo.Get(templateInstanceUserId);

                if (null != user)
                {
                    if (!CanAnswerResearch(user.TemplateInstanceId))
                    {
                        throw new InvalidOperationException(
                            "Template instance is completed or user does not have permission");
                    }

                    _unitOfWork.TemplateInstanceUserRepo.Delete(user);
                    _unitOfWork.Save();
                }
            }
        }

        public int CreateUser(int templateInstanceId, int userAccountId)
        {
            if (!CanAnswerResearch(templateInstanceId, out var tempInstance))
            {
                throw new InvalidOperationException(
                    "Template instance is completed or user does not have permission");
            }

            using (_unitOfWork)
            {
                var user = new data.Models.Template.TemplateInstanceUser()
                {
                    TemplateInstanceId = templateInstanceId,
                    UserAccountId = userAccountId,
                    UserAccount = null
                };

                _unitOfWork.TemplateInstanceUserRepo.Create(user);
                _unitOfWork.Save();

                return user.Id;
            }
        }

        public void DeleteMultiselectAnswer(
            model.Research.TemplateInstanceAnswer templateInstanceAsnwer, 
            int multiselectAnswerId)
        {
            if (!CanAnswerResearch(templateInstanceAsnwer.TemplateInstanceId))
            {
                throw new InvalidOperationException(
                    "Template instance is completed or user does not have permission");
            }

            using(_unitOfWork)
            {
                var data = _unitOfWork.TemplateInstanceAnswerRepo.Get(
                    templateInstanceAsnwer.TemplateInstanceId, 
                    templateInstanceAsnwer.TemplateSectionId, 
                    templateInstanceAsnwer.SectionQuestionId,
                    multiselectAnswerId);

                if (data != null)
                {
                    _unitOfWork.TemplateInstanceAnswerRepo.Delete(data);
                    _unitOfWork.Save();
                }
            }
        }

        public void DeleteRepeatableSectionAnswers(
            int templateInstanceId, 
            int templateSectionId, 
            int answerGroupIndex)
        {
            if (!CanAnswerResearch(templateInstanceId))
            {
                throw new InvalidOperationException(
                    "Template instance is completed or user does not have permission");
            }

            using (_unitOfWork)
            {
                var data = _unitOfWork.TemplateInstanceAnswerRepo
                    .GetRepeatableSectionAnswers(
                    templateInstanceId, 
                    templateSectionId, 
                    answerGroupIndex);

                if(data != null && data.Any())
                {
                    var dataArray = data.ToArray();
                    foreach (var item in dataArray)
                    {
                        _unitOfWork.TemplateInstanceAnswerRepo.Delete(item);
                    }

                    _unitOfWork.Save();
                }
            }
        }

        public void SaveAnswers(IEnumerable<model.Research.TemplateInstanceAnswer> answers)
        {
            if(answers == null || 
                !answers.Any())
            {
                return;
            }

            var tempInstanceId = answers.First().TemplateInstanceId;

            if (!CanAnswerResearch(tempInstanceId))
            {
                throw new InvalidOperationException(
                    "Template instance is completed or user does not have permission");
            }

            var data = answers.Map().ToArray();

            using(_unitOfWork)
            {
                var existingAnswers = _unitOfWork.TemplateInstanceAnswerRepo.GetByTemplateInstance(tempInstanceId);
                var tempSections = _unitOfWork.TemplateInstanceRepo.GetTemplateQuestions(tempInstanceId);

                foreach (var answer in data)
                {
                    //get question type
                    var questionType = tempSections
                        .Where(e => e.Id == answer.TemplateSectionId)
                        .First()
                        .Section
                        .SectionQuestions
                        .Where(e => e.Id == answer.SectionQuestionId)
                        .First()
                        .Question
                        .QuestionType;
                    
                    var existing = existingAnswers.Where(e =>
                        e.TemplateSectionId == answer.TemplateSectionId &&
                        e.SectionQuestionId == answer.SectionQuestionId)
                        .ToArray();

                    if(answer.AnswerGroupIndex != null)
                    {
                        existing = existingAnswers.Where(e =>
                            e.TemplateSectionId == answer.TemplateSectionId &&
                            e.SectionQuestionId == answer.SectionQuestionId &&
                            e.AnswerGroupIndex == answer.AnswerGroupIndex)
                            .ToArray();
                    }

                    if(questionType.HasMultipleSelection)
                    {
                        var multiSelectAnswer = 
                            existing.Where(e => e.AnswerValue == answer.AnswerValue)
                            .FirstOrDefault();
                        if(null == multiSelectAnswer)
                        {
                            answer.Id = 0;
                            _unitOfWork.TemplateInstanceAnswerRepo.Insert(answer);
                        }
                    }
                    else
                    {
                        if(existing.Any())
                        {
                            var firstExisting = existing.First();
                            if(answer.AnswerValue != firstExisting.AnswerValue)
                            {
                                answer.Id = firstExisting.Id;
                               _unitOfWork.TemplateInstanceAnswerRepo.Update(answer);
                            }
                        }
                        else
                        {
                            answer.Id = 0;
                            _unitOfWork.TemplateInstanceAnswerRepo.Insert(answer);
                        }
                    }
                }

                foreach (var existing in existingAnswers)
                {
                    if(existing.SectionQuestion.Question.QuestionType.HasMultipleSelection)
                    {
                        if (!data
                            .Where(e => e.TemplateSectionId == existing.TemplateSectionId &&
                                e.SectionQuestionId == existing.SectionQuestionId && 
                                e.AnswerValue == existing.AnswerValue)
                            .Any())
                        {
                            existing.SectionQuestion = null;
                            _unitOfWork.TemplateInstanceAnswerRepo.Delete(existing);
                        }
                    }
                    else
                    {
                        if (!data
                            .Where(e => e.TemplateSectionId == existing.TemplateSectionId &&
                                e.SectionQuestionId == existing.SectionQuestionId &&
                                e.AnswerGroupIndex == existing.AnswerGroupIndex)
                            .Any())
                        {
                            existing.SectionQuestion = null;
                            _unitOfWork.TemplateInstanceAnswerRepo.Delete(existing);
                        }
                    }
                }

                _unitOfWork.Save();
            }
        }

        public bool CanAnswerResearch(int templateInstanceId)
        {
            return CanAnswerResearch(templateInstanceId, out var tempInstance);
        }

        public bool CanAnswerResearch(int templateInstanceId, out data.Models.Template.TemplateInstance templateInstanceUsed)
        {
            var tempInstance = _unitOfWork.TemplateInstanceRepo.Get(templateInstanceId, false);
            templateInstanceUsed = tempInstance;

            if (null != tempInstance)
            {
                if (tempInstance.CompletedOnUtc.HasValue)
                {
                    return false;
                }

                if (tempInstance.TemplateUsers != null &&
                    !tempInstance.TemplateUsers.Select(e => e.UserAccountId).Contains(_userIdentity.UserId) &&
                    tempInstance.CreatedByUserAccountId != _userIdentity.UserId)
                {
                    return false;
                }
            }

            return true;
        }

        public IEnumerable<ResearchFormVendor> GetVendorsSelected(int templateInstanceId)
        {
            var answers = _unitOfWork.TemplateInstanceAnswerRepo
                .GetByTemplateInstance(templateInstanceId, true, true);

            var vendors = new List<ResearchFormVendor>();

            if (null == answers)
            {
                return vendors;
            }

            var allVendorDataAnswers = answers
                .Where(e => e.TemplateSection.GlobalId == FormIds.SectionIIIVendorInfo)
                .OrderBy(e => e.AnswerGroupIndex)
                .GroupBy(e => e.AnswerGroupIndex);

            foreach (var items in allVendorDataAnswers)
            {
                var vendorAnswers = items.Select(e => e).ToList();
                var vendor = new ResearchFormVendor();
                vendor.Id = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorId, vendorAnswers);
                vendor.CageDuns = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorCageDuns, vendorAnswers);
                vendor.Capability = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorCapabilites, vendorAnswers);
                vendor.SetAside = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorSocioeconomicStatus, vendorAnswers);
                vendor.Location = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorLocation, vendorAnswers);
                vendor.Name = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorName, vendorAnswers);
                vendor.PastPerformance = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorPerformance, vendorAnswers);
                vendor.PointOfContact = GetFormValue(FormIds.SectionIIIVendorInfo, FormIds.QuestionVendorContact, vendorAnswers);

                vendors.Add(vendor);
            }

            var dbVendors = _unitOfWork.VendorRepo.Get(vendors.Select(e => int.Parse(e.Id)));
            foreach( var vendor in vendors)
            {
                var sustainment = dbVendors.FirstOrDefault(e => e.Id.ToString() == vendor.Id);
                if(null != sustainment)
                {
                    vendor.SustainmentId = sustainment.SustainmentId;
                }
            }

            return vendors;
        }

        private data.Models.Template.TemplateInstance GetTemplateInstanceAndTemplate(int id)
        {
            var instance = _unitOfWork.TemplateInstanceRepo.Get(id, true);

            if (instance != null)
            {
            var temp = _unitOfWork.TemplateRepo.Get(instance.TemplateId);
                instance.Template = temp;
            }

            return instance;
        }

        private void MergeData(IEnumerable<VendorSearch> vendors)
        {
            var sustainmentIds = vendors.Select(e => {
                return e.SustainmentVendorId.Length < 9 && (e.SustainmentVendorId.PadLeft(9, '0') == e.DUNSId) ?
                e.DUNSId :
                e.SustainmentVendorId;
            }).ToList();

            //var mrVendors = _unitOfWork.VendorRepo.Get(cageCodes, duns, names);
            var mrVendors = _unitOfWork.VendorRepo.Get(sustainmentIds);

            foreach (var item in vendors)
            {
                var mrVendor = mrVendors.FirstOrDefault(e => e.SustainmentId == item.SustainmentVendorId);
                if (null != mrVendor)
                {
                    item.ResearchVendorId = mrVendor.Id;
                }
            }
        }

        private int CreateTemplateInstance(StartResearchRequest request)
        {
            var newTemplateInstance = new data.Models.Template.TemplateInstance();
            newTemplateInstance.BidTypeId = request.FormTemplate.BidTypeId;
            newTemplateInstance.CreatedByUserAccountId = _userIdentity.UserId;
            newTemplateInstance.CreatedOnUtc = DateTime.UtcNow;
            newTemplateInstance.ItemEstimatedValue = request.InitiateResponse.InitiateSummary.ItemEstimatedValue;
            newTemplateInstance.ItemEstimatedValue = request.InitiateResponse.InitiateSummary.ItemQuantity;
            newTemplateInstance.Name = request.FormTemplate.Name;
            newTemplateInstance.Nsn = request.InitiateResponse.InitiateSummary.Nsn;
            newTemplateInstance.OrgId = request.FormTemplate.OrgId;
            newTemplateInstance.OriginalTemplateName = request.FormTemplate.Name;
            newTemplateInstance.PurchaseRequestProcessingSystemId = request.InitiateResponse.InitiateSummary.PurchaseRequestProcessingSystemId;
            newTemplateInstance.ServiceTypeId = request.FormTemplate.ServiceTypeId;
            newTemplateInstance.SourceTypeId = request.FormTemplate.SourceTypeId;
            newTemplateInstance.TemplateId = request.FormTemplate.Id;

            //if (request.InitiateResponse.Awards != null &&
            //    request.InitiateResponse.Awards.Any())
            //{
            //    foreach (var award in request.InitiateResponse.Awards)
            //    {
            //        var vendor = new TemplateInitiateVendor();
            //        vendor.PartNumber = award.PartNumber;
            //        vendor.TemplateInstanceId = newTemplateInstance.Id;
            //        vendor.VendorCageCode = award.Vendor.CageCode;
            //        vendor.VendorName = award.Vendor.Name;
            //        newTemplateInstance.TemplateInitiateVendors.Add(vendor);
            //    }
            //}

            if (request.InitiateResponse.SuggestedVendors != null &&
                request.InitiateResponse.SuggestedVendors.Any())
            {
                foreach (var vendor in request.InitiateResponse.SuggestedVendors)
                {
                    var tempInstVendor = new TemplateInitiateVendor();
                    tempInstVendor.DUNSId = vendor.DUNSId;
                    tempInstVendor.Ranking = vendor.Ranking;
                    tempInstVendor.SustainmentId = vendor.SustainmentVendorId;
                    tempInstVendor.TemplateInstanceId = newTemplateInstance.Id;
                    tempInstVendor.VendorCageCode = vendor.CageCode;
                    tempInstVendor.VendorId = vendor.ResearchVendorId;
                    tempInstVendor.VendorName = vendor.Name;

                    newTemplateInstance.TemplateInitiateVendors.Add(tempInstVendor);
                }
            }

            using (_unitOfWork)
            {
                _unitOfWork.TemplateInstanceRepo.Create(newTemplateInstance);
                _unitOfWork.Save();
            }

            return newTemplateInstance.Id;
        }

        private void SetVendorParts(
            InitiateResponse response,
            GetNationalStockNumberResponse data)
        {
            if (data.VendorParts != null &&
                data.VendorParts.Any())
            {
                response.Awards = data.VendorParts
                    .Where(e => 
                    !string.IsNullOrWhiteSpace(e.VendorName) &&
                    !string.IsNullOrWhiteSpace(e.CAGECode))
                    .Select(e =>
                    {
                        return new InitiateAward()
                        {
                            PartNumber = e.PartNumber,
                            Vendor = new VendorSummary()
                            {
                                CageCode = e.CAGECode,
                                Name = e.VendorName
                                //,DunsId
                            }
                        };
                    })
                    .ToList();
            }
            else
            {
                response.Awards = new List<InitiateAward>();
            }
        }

        private void SetProposedBidType(
            InitiateResponse response,
            GetNationalStockNumberResponse data)
        {
            if (data.BidType == (int)model.Research.BidType.OpenBid)
            {
                response.ProposedBidType = model.Research.BidType.OpenBid;
            }
            else if (data.BidType == (int)model.Research.BidType.ClosedBid)
            {
                response.ProposedBidType = model.Research.BidType.ClosedBid;
            }
            else
            {
                response.ProposedBidType = model.Research.BidType.Unknown;
            }
        }

        private SearchQueueResponse BuildErroResponse(HttpResponseMessage httpResponseMessage)
        {
            return new SearchQueueResponse()
            {
                ProcessMessage = "Error",
                ProcessStatusDescription = $"Error calling Odysseus API. Status Code- { httpResponseMessage?.StatusCode }, Reason Phrase- { httpResponseMessage?.ReasonPhrase }"
            };
        }

        private void SetInitiateSummary(InitiateResponse response, InitiateRequest request)
        {
            response.InitiateSummary = new InitiateSummary();
            response.InitiateSummary.Nsn = request.Nsn;
            response.InitiateSummary.ItemQuantity = request.ItemQuantity;
            response.InitiateSummary.ItemEstimatedValue = request.ItemEstimatedValue;
            response.InitiateSummary.ServiceTypeName = request.ServiceType.ToString();
            response.InitiateSummary.SourceTypeName = request.SourceType.ToString();
            response.InitiateSummary.PurchaseRequestProcessingSystemId = request.PurchaseRequestProcessingSystemId;
        }
    }
}
