using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Template
{
    public class CustomSelectAnswer : IEntity
    {
        public int Id { get; set; }

        public int QuestionId { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int OrderIndex { get; set; }

        public string GlobalId { get; set; }
    }
}
