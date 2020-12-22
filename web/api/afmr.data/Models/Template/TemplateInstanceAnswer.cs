using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateInstanceAnswer : IEntity
    {
        public int Id { get; set; }

        public int TemplateInstanceId { get; set; }

        public int TemplateSectionId { get; set; }

        public int SectionQuestionId { get; set; }

        public int? AnswerGroupIndex { get; set; }

        public string AnswerValue { get; set; }

        [ForeignKey(nameof(TemplateSectionId))]
        public TemplateSection TemplateSection { get; set; }

        [ForeignKey(nameof(SectionQuestionId))]
        public SectionQuestion SectionQuestion { get; set; }

    }
}
