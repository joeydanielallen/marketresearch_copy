using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors
{
    public class Vendor
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string CAGECode { get; set; }

        public string DUNSId { get; set; }

        public int? SetAsideId { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateAbbreviation { get; set; }

        public string PostalCode { get; set; }

        public string Capability { get; set; }

        public string PastPerformance { get; set; }

        public string SustainmentId { get; set; }

        public SetAside SetAside { get; set; }

        public IEnumerable<VendorContact> VendorContacts { get; set; }

        public IEnumerable<VendorPart> VendorParts { get; set; }

        public IEnumerable<VendorNote> VendorNotes { get; set; }


    }
}
