using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Sustainment.Vendors
{
    public class VendorByNsn
    {
        public int Id { get; set; }
        public string Duns { get; set; }
        public string Cage { get; set; }
        public string Name { get; set; }
        public decimal Score { get; set; }
    }
}
