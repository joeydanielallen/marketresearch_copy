using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class FormTemplateAdmin
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public IEnumerable<BidType> BidTypes { get; set; }

        public IEnumerable<Org> Orgs { get; set; }

        public IEnumerable<ServiceType> ServiceTypes { get; set; }

        public IEnumerable<SourceType> SourceTypes { get; set; }
    }
}
