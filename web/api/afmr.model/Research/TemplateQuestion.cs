using System.Collections.Generic;

namespace afmr.model.Research
{
    public class TemplateQuestion
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderIndex { get; set; }

        public AnswerType AnswerType { get; set; }

        public bool AllowMultipleSelectAnswers { get; set; }

        /// <summary>
        /// Max length for small or large text and multiselect answer types
        /// </summary>
        public int MaxLength { get; set; }

        /// <summary>
        /// Set to 0 for repeatable sets of questions
        /// </summary>
        public int? GroupIndex { get; set; }

        public IEnumerable<QuestionAnswer> QuestionAnswers {get; set;}

        //public IEnumerable<object> Answers { get; set; }
    }
}