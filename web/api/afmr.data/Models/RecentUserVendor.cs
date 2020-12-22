using afmr.data.Models.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.data.Models
{
    public class RecentUserVendor: IEntity
    {
        public int Id { get; set; }

        public int UserAccountId { get; set; }

        public int VendorId { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public Vendor Vendor { get; set; }
    }
}
