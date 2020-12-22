using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors
{
    public class VendorSearch
    {
        public string SustainmentVendorId { get; set; }

        public int? ResearchVendorId { get; set; }

        public string DUNSId { get; set; }

        public string CageCode { get; set; }

        public string Name { get; set; }

        public decimal Ranking { get; set; }
    }
}
