using afmr.data.Models;
using afmr.data.Models.Template;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace afmr.data.Repos.Templates
{
    public class TemplateInstanceRepo : RepoBase<TemplateInstance>, ITemplateInstanceRepo
    {
        public TemplateInstanceRepo(MarketResearchDbContext dbContext) : base(dbContext) { }

        public void Create(TemplateInstance templateInstance)
        {
            base.Insert(templateInstance);
        }

        public IEnumerable<TemplateInstance> GetByNSN(string nsn)
        {
            var instances = Get()
                .Include(e => e.CreatedByUser)
                .Include(e => e.Org)
                .Include(e => e.BidType)
                .Include(e => e.SourceType)
                .Include(e => e.ServiceType)                
                .Include(e => e.Template.TemplateBidTypes)
                .Include(e => e.Template.TemplateServiceTypes)
                .Include(e => e.Template.TemplateSourceTypes)
                .Where(e => e.Nsn == nsn)
                .ToList();

            return instances;
        }

        public TemplateInstance GetForDelete(int id)
        {
            return Get()
                .Include(e => e.TemplateUsers)
                .Include(e => e.TemplateInstanceAnswers)
                .Include(e => e.TemplateInitiateVendors)
                .Where(e => e.Id == id)
                .FirstOrDefault();
        }
        
        public TemplateInstance Get(int id, bool includeChildren = true)
        {
            if(!includeChildren)
            {
                return Get()
                    .Include(e => e.CreatedByUser)
                    .Where(e => e.Id == id)
                    .FirstOrDefault();
            }

            var templateInstance = Get()
                .Include(e => e.CreatedByUser)
                .Include(e => e.Org)
                .Include(e => e.TemplateUsers)
                    .ThenInclude(k => k.UserAccount)
                .Include(e => e.BidType)
                .Include(e => e.SourceType)
                .Include(e => e.ServiceType)
                .Include(e => e.TemplateInstanceAnswers)
                    .ThenInclude(e => e.TemplateSection)
                .Include(e => e.TemplateInstanceAnswers)
                    .ThenInclude(e => e.SectionQuestion)
                .Include(e => e.TemplateInitiateVendors)

                //.Include(e => e.Template.TemplateBidTypes)
                //.Include(e => e.Template.TemplateServiceTypes)
                //.Include(e => e.Template.TemplateSourceTypes)
                //.Include(e => e.Template.TemplateOrgs)
                //    .ThenInclude(e => e.Org)
                //.Include(e => e.Template.TemplateSections)
                //    .ThenInclude(e => e.TemplateSectionGroup)
                //.Include(e => e.Template.TemplateSections)
                //    .ThenInclude(e => e.Section)
                //        .ThenInclude(e => e.SectionQuestions)
                //            .ThenInclude(e => e.Question)
                //                .ThenInclude(e => e.CustomSelectAnswers)
                //.Include(e => e.Template.TemplateSections)
                //    .ThenInclude(e => e.Section)
                //        .ThenInclude(e => e.SectionQuestions)
                //            .ThenInclude(e => e.Question)
                //                .ThenInclude(e => e.QuestionType)
                .Where(e => e.Id == id)
                .FirstOrDefault();

            if(null != templateInstance)
            {
                //templateInstance.Template.TemplateSections = 
                //    templateInstance
                //    .Template
                //    .TemplateSections
                //    .OrderBy(e => e.OrderIndex)
                //    .ToList();

                //var tempSections = templateInstance.Template.TemplateSections.ToArray();
                //for (int index = 0; index < tempSections.Length; index++)
                //{
                //    var tempSection = tempSections[index];
                //    if (tempSection.Section.SectionQuestions != null &&
                //        tempSection.Section.SectionQuestions.Any())
                //    {
                //        tempSection.Section.SectionQuestions = tempSection.Section.SectionQuestions.OrderBy(e => e.OrderIndex).ToList();
                //    }
                //}

                if(templateInstance.TemplateInstanceAnswers.Any())
                {
                    templateInstance.TemplateInstanceAnswers =
                        templateInstance.TemplateInstanceAnswers
                        .OrderBy(e => e.TemplateSection.OrderIndex)
                        .ThenBy(e => e.SectionQuestion.OrderIndex)
                        .ThenBy(e => e.AnswerGroupIndex);
                }
            }

            return templateInstance;
        }

        public IEnumerable<TemplateInstance> GetByUserId(int userId)
        {
            return Get()
                .Include(e => e.CreatedByUser)
                .Include(e => e.TemplateUsers)
                    .ThenInclude(e => e.UserAccount)
                .Where(e => e.CreatedByUserAccountId == userId ||
                e.TemplateUsers.Select(e => e.UserAccountId).Contains(userId))
                .OrderByDescending(e => e.CreatedOnUtc)
                .ThenBy(e => e.CompletedOnUtc)
                .ToList();
        }

        public IEnumerable<TemplateInstance> GetInProgressForUser(int userId)
        {
            return Get()
                .Include(e => e.CreatedByUser)
                .Include(e => e.TemplateUsers)
                    .ThenInclude(e => e.UserAccount)
                .Where(e => 
                e.CompletedOnUtc == null &&
                (e.CreatedByUserAccountId == userId ||
                e.TemplateUsers.Select(e => e.UserAccountId).Contains(userId)))
                .OrderByDescending(e => e.CreatedOnUtc)
                .ThenBy(e => e.CompletedOnUtc)
                .ToList();
        }

        public IEnumerable<TemplateSection> GetTemplateQuestions(int templateInstanceId)
        {
            var tempSections = new List<TemplateSection>();

            var templateInstance = Get()
                .Include(e => e.Template)
                    .ThenInclude(e => e.TemplateSections)
                        .ThenInclude(e => e.Section)
                            .ThenInclude(e => e.SectionQuestions)
                                .ThenInclude(e => e.Question)
                                    .ThenInclude(e => e.QuestionType)                                    
                .Where(e => e.Id == templateInstanceId)
                .FirstOrDefault();
            if(null == templateInstance)
            {
                return tempSections;
            }

            tempSections = templateInstance.Template.TemplateSections.ToList();

            return tempSections;
        }
    }
}
