using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class SectionQuestion : IEntity
    {
        public int Id { get; set; }

        public int SectionId { get; set; }

        public int QuestionId { get; set; }

        public int OrderIndex { get; set; }

        public string GlobalId { get; set; }

        [ForeignKey(nameof(QuestionId))]
        public Question Question { get; set; }
    }
}
