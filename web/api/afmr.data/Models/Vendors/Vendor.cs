using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Vendors
{
    public class Vendor : IEntity
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CAGECode { get; set; }

        public string DUNSId { get; set; }

        public int? SetAsideId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2{ get; set; }

        public string City { get; set; }

        public string StateAbbreviation { get; set; }

        public string PostalCode { get; set; }

        public string Capability { get; set; }

        public string PastPerformance { get; set; }

        public string SustainmentId { get; set; }


        [ForeignKey(nameof(SetAsideId))]
        public SetAside SetAside { get; set; }

        public IEnumerable<VendorContact> VendorContacts { get; set; }

        public IEnumerable<VendorPart> VendorParts { get; set; }

        public IEnumerable<VendorNote> VendorNotes { get; set; }
    }
}
