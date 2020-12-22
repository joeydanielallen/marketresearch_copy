using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateInitiateVendor : IEntity
    {
        public int Id { get; set; }

        public int TemplateInstanceId { get; set; }

        public int? VendorId { get; set; }

        public string VendorName { get; set; }

        public string VendorCageCode { get; set; }

        public string DUNSId { get; set; }

        public decimal Ranking { get; set; }

        public string SustainmentId { get; set; }

        public TemplateInstance TemplateInstance { get; set; }
    }
}
