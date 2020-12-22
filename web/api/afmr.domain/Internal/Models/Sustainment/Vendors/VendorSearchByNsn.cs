using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Sustainment.Vendors
{
    internal class VendorSearchByNsn
    {
        public IEnumerable<VendorByNsn> Results { get; set; } = new List<VendorByNsn>();
    }
}
