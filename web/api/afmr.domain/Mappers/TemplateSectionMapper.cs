using afmr.model.Research;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace afmr.domain.Mappers
{
    public static partial class Mapper
    {
        public static TemplateSection Map(this data.Models.Template.TemplateSection data)
        {
            if (data == null) return null;
            var model = new TemplateSection();

            model.Description = data.Section.Description;
            model.Id = data.Id;
            model.Name = data.Section.Name;
            model.HasQuestionGrouping = data.Section.CanRepeat;
            model.SystemControlTypeId = data.Section.SystemControlTypeId;
            model.CanDelete = data.Section.CanDelete;
            model.OrderIndex = data.OrderIndex;
            model.SectionId = data.SectionId;
            model.TemplateId = data.TemplateId;
            model.TemplateSectionGroupId = data.TemplateSectionGroupId;
            model.TemplateSectionGroup = data.TemplateSectionGroupId.HasValue ?
                new TemplateSectionGroup()
                {
                    Description = data.TemplateSectionGroup.Description,
                    Id = data.TemplateSectionGroupId.Value,
                    Name = data.TemplateSectionGroup.Name
                } : null;
            model.Questions = data.Section.SectionQuestions.Select(e => e.Map(data.Section.CanRepeat));

            return model;
        }
    }
}

