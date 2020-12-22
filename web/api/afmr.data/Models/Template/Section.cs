using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Template
{
    public class Section : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public bool CanRepeat { get; set; }

        public bool CanDelete { get; set; }

        public int? SystemControlTypeId { get; set; }

        public IEnumerable<SectionQuestion> SectionQuestions { get; set; }
    }
}
