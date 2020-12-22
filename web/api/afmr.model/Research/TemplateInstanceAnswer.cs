using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class TemplateInstanceAnswer
    {
        public int Id { get; set; }

        public int TemplateInstanceId { get; set; }

        public int TemplateSectionId { get; set; }

        public int SectionQuestionId { get; set; }

        public int? AnswerGroupIndex { get; set; }

        public string AnswerValue { get; set; }
    }
}
