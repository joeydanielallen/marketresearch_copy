using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateSection : IEntity
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int SectionId { get; set; }

        public int OrderIndex { get; set; }

        public int? TemplateSectionGroupId { get; set; }

        public string GlobalId { get; set; }

        [ForeignKey(nameof(SectionId))]
        public Section Section { get; set; }

        [ForeignKey(nameof(TemplateSectionGroupId))]
        public TemplateSectionGroup TemplateSectionGroup { get; set; }
    }
}
