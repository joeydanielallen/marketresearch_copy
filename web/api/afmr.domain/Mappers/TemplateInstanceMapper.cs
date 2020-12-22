using afmr.data.Models.Template;
using afmr.model.Research;
using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static model.Research.TemplateInstance Map(this data.Models.Template.TemplateInstance data)
        {
            if (data == null) return null;
            var model = new model.Research.TemplateInstance();

            model.AppUsers = data.TemplateUsers.Select(e => e.UserAccount.MapToAppUser(e.Id));
            model.BidType = (BidType)data.BidTypeId;
            model.CompletedOn = SetUtcDateTimeKind(data.CompletedOnUtc);
            model.CreatedByAppUser = data.CreatedByUser.MapToAppUser(null);
            model.CreatedOn = SetUtcDateTimeKind(data.CreatedOnUtc);
            model.Id = data.Id;
            model.ItemEstimatedValue = data.ItemEstimatedValue;
            model.ItemQuantity = data.ItemQuantity;
            model.Name = data.Name;
            model.Nsn = data.Nsn;
            model.Org = data.Org.Map();
            model.OriginalTemplateName = data.OriginalTemplateName;
            model.PurchaseRequestProcessingSystemId = data.PurchaseRequestProcessingSystemId;
            model.UnsuggestedTemplateUseReason = data.UnsuggestedTemplateUseReason;
            model.ServiceType = (ServiceType)data.ServiceTypeId;
            model.SourceType = (SourceType)data.SourceTypeId;
            model.TemplateId = data.TemplateId;
            model.Template = data.Template.Map();
            model.Answers = data.TemplateInstanceAnswers.Select(e => new model.Research.TemplateInstanceAnswer()
            {
                AnswerGroupIndex = e.AnswerGroupIndex,
                AnswerValue = e.AnswerValue,
                Id = e.Id,
                SectionQuestionId = e.SectionQuestionId,
                TemplateInstanceId = e.TemplateInstanceId,
                TemplateSectionId = e.TemplateSectionId
            });

            model.SuggestedVendors = data.TemplateInitiateVendors.Select(e => new model.Vendors.VendorSearch()
            {
                CageCode = e.VendorCageCode,
                DUNSId = e.DUNSId,
                Name = e.VendorName,
                Ranking = e.Ranking,
                ResearchVendorId = e.VendorId,
                SustainmentVendorId = e.SustainmentId
            });

            

            return model;
        }

        public static PriorResearchSummary MapToSummary(this data.Models.Template.TemplateInstance data)
        {
            if (data == null) return null;
            var model = new PriorResearchSummary();

            model.BidTypeName = data.BidType.Name;
            model.CompletionDate = data.CompletedOnUtc.HasValue ? SetUtcDateTimeKind(data.CompletedOnUtc.Value) : (DateTime?)null;
            model.TemplateInstanceId = data.Id;
            model.ItemEstimatedValue = data.ItemEstimatedValue;
            model.ItemQuantity = data.ItemQuantity;
            model.OrgName = data.Org.Name;
            model.PurchaseRequestProcessingSystemId = data.PurchaseRequestProcessingSystemId;
            model.ServiceTypeName = data.ServiceType.Name;
            model.ServiceTypeName = data.SourceType.Name;
            model.TemplateName = data.Name;
            
            // TODO 
            //model.Vendors


            return model;
        }
    }
}
