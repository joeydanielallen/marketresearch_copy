using System.Collections.Generic;

namespace afmr.model.Research
{
    public class FormTemplate
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int BidTypeId { get; set; }

        public string BidTypeName { get; set; }
        
        public int OrgId { get; set; }

        public string OrgName { get; set; }

        public int ServiceTypeId { get; set; }

        public string ServiceTypeName { get; set; }

        public int SourceTypeId { get; set; }

        public string SourceTypeName { get; set; }

        public bool IsActive { get; set; }
    }
}