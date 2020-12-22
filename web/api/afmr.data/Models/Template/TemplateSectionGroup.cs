using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateSectionGroup : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
    }
}
