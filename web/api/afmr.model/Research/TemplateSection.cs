using System.Collections.Generic;

namespace afmr.model.Research
{
    public class TemplateSection
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int SectionId { get; set; }

        public int SubIndex { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasQuestionGrouping { get; set; }

        public int? SystemControlTypeId { get; set; }

        public bool CanDelete { get; set; }

        public int OrderIndex { get; set; }

        public int? TemplateSectionGroupId { get; set; }

        public TemplateSectionGroup TemplateSectionGroup { get; set; }

        public IEnumerable<TemplateQuestion> Questions { get; set; }
    }
}