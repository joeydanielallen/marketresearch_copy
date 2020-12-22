using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models.Template
{
    public class Template : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public decimal MinEstimatedValue { get; set; }

        public decimal MaxEstimatedValue { get; set; }

        public bool IsActive { get; set; }

        public IEnumerable<TemplateBidType> TemplateBidTypes { get; set; }

        public IEnumerable<TemplateOrg> TemplateOrgs { get; set; }

        public IEnumerable<TemplateServiceType> TemplateServiceTypes { get; set; }

        public IEnumerable<TemplateSourceType> TemplateSourceTypes { get; set; }

        public IEnumerable<TemplateSection> TemplateSections { get; set; }
    }
}
