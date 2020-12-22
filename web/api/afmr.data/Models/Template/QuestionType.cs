using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Template
{
    public class QuestionType
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool HasMultipleSelection { get; set; }
    }
}
