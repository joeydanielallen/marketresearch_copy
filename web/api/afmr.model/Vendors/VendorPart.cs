using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors
{
    public class VendorPart
    {
        public int Id { get; set; }
        public int VendorId { get; set; }

        public string PartNumber { get; set; }

        public string Nsn { get; set; }

        public string Description { get; set; }
    }
}
