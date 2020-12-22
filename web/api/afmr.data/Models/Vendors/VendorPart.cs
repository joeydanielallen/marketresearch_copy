using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Vendors
{
    public class VendorPart : IEntity
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string PartNumber { get; set; }

        public string Nsn { get; set; }

        public string Description { get; set; }

        [ForeignKey(nameof(VendorId))]
        public Vendor Vendor { get; set; }
    }
}
