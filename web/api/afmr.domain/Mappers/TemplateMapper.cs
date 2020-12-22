using afmr.model.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static Template Map(this data.Models.Template.Template data)
        {
            if (data == null) return null;
            var model = new Template();

            model.BidTypes = data.TemplateBidTypes.Select(e => (BidType)e.BidTypeId);
            model.Description = data.Description;
            model.Id = data.Id;
            model.IsActive = data.IsActive;
            model.MaxEstimatedValue = data.MaxEstimatedValue;
            model.MinEstimatedValue = data.MinEstimatedValue;
            model.Name = data.Name;
            model.Orgs = data.TemplateOrgs.Select(e => e.Org.Map());
            model.ServiceTypes = data.TemplateServiceTypes.Select(e => (ServiceType)e.ServiceTypeId);
            model.SourceTypes = data.TemplateSourceTypes.Select(e => (SourceType)e.SourceTypeId);
            model.Sections = data.TemplateSections.Select(e => e.Map()).ToArray();

            for (int index = 0; index < model.Sections.Count(); index++)
            {
                var section = model.Sections.ElementAt(index);
                if (index == 0)
                {
                    section.SubIndex = section.TemplateSectionGroupId.HasValue ? 1 : 0;
                }

                TemplateSection priorSection = index > 0 ? model.Sections.ElementAt(index - 1) : null;
                if(null != priorSection)
                {
                    if(section.TemplateSectionGroupId.HasValue && 
                        priorSection.TemplateSectionGroupId.HasValue && 
                        section.TemplateSectionGroupId.Value == priorSection.TemplateSectionGroupId.Value)
                    {
                        section.SubIndex = priorSection.SubIndex + 1;
                    }
                    else
                    {
                        section.SubIndex = 0;
                    }
                }
            }

            return model;
        }

        public static IEnumerable<FormTemplate> MapToFormTemplate(
            this data.Models.Template.Template data,
            IEnumerable<int> orgIds,
            int bidTypeId, 
            int serviceTypeId, 
            int sourceTypeId,
            decimal estimatedValue,
            bool exclusions = false)
        {
            if (data == null) return null;
            var model = new List<FormTemplate>();

            var flatTemplates =
                from org in data.TemplateOrgs
                from bid in data.TemplateBidTypes
                from svc in data.TemplateServiceTypes
                from src in data.TemplateSourceTypes
                select new { 
                    OrgId = org.Org.Id, 
                    OrgName = org.Org.Name, 
                    BidId = bid.BidType.Id, 
                    BidName = bid.BidType.Name,
                    SvcId = svc.ServiceType.Id, 
                    SvcName = svc.ServiceType.Name,
                    SrcId = src.SourceType.Id,
                    SrcName = src.SourceType.Name
                };

            if (!exclusions)
            {
                foreach (var item in flatTemplates)
                {
                    if (data.MinEstimatedValue <= estimatedValue &&
                    data.MaxEstimatedValue >= estimatedValue && 
                    orgIds.Contains(item.OrgId) && 
                    item.BidId == bidTypeId && 
                    item.SrcId == sourceTypeId && 
                    item.SvcId == serviceTypeId)
                    {
                        var formTemplate = new FormTemplate();
                        formTemplate.Description = data.Description;
                        formTemplate.Id = data.Id;
                        formTemplate.Name = data.Name;
                        formTemplate.OrgId = item.OrgId;
                        formTemplate.OrgName = item.OrgName;
                        formTemplate.BidTypeId = bidTypeId;
                        formTemplate.BidTypeName = item.BidName; // data.TemplateBidTypes.First(e => e.BidTypeId == bidTypeId).BidType.Name;
                        formTemplate.ServiceTypeId = item.SrcId;
                        formTemplate.ServiceTypeName = item.SvcName;
                        formTemplate.SourceTypeId = item.SrcId;
                        formTemplate.SourceTypeName = item.SrcName;
                        formTemplate.IsActive = data.IsActive;

                        model.Add(formTemplate);
                    }

                }
            }
            else
            {
                foreach (var item in flatTemplates)
                {
                    if (orgIds.Contains(item.OrgId) &&
                        ((data.MinEstimatedValue > estimatedValue || data.MaxEstimatedValue < estimatedValue) ||
                        item.SvcId != serviceTypeId ||
                        item.SrcId != sourceTypeId ||
                        item.BidId != bidTypeId))
                    {
                        var formTemplate = new FormTemplate();
                        formTemplate.Description = data.Description;
                        formTemplate.Id = data.Id;
                        formTemplate.Name = data.Name;
                        formTemplate.OrgId = item.OrgId;
                        formTemplate.OrgName = item.OrgName;
                        formTemplate.BidTypeId = item.BidId;
                        formTemplate.BidTypeName = item.BidName;
                        formTemplate.ServiceTypeId = item.SvcId;
                        formTemplate.ServiceTypeName = item.SvcName;
                        formTemplate.SourceTypeId = item.SrcId;
                        formTemplate.SourceTypeName = item.SrcName;

                        model.Add(formTemplate);
                    }
                }
            }

            return model;
        }
    }
}
