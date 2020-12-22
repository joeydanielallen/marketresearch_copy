using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class Question
    {
        public int Id { get; set; }
        
        public string Name { get; set; }

        public string Description { get; set; }

        public int QuestionTypeId { get; set; }

        public int MaxLength { get; set; }

        [ForeignKey(nameof(QuestionTypeId))]
        public QuestionType QuestionType { get; set; }

        [ForeignKey("QuestionId")]
        public IEnumerable<CustomSelectAnswer> CustomSelectAnswers { get; set; }
    }
}
