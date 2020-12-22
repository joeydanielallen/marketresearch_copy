using afmr.data.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Vendors
{
    public class VendorContact : IEntity
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public string AddressLine1 { get; set; }

        public string AddressLine2 { get; set; }

        public string City { get; set; }

        public string StateAbbreviation { get; set; }

        public string PostalCode { get; set; }

        public int SavedByUserAccountId { get; set; }

        public DateTime SavedOnUtc { get; set; }

        [ForeignKey(nameof(SavedByUserAccountId))]
        public UserAccount UserAccount { get; set; }
    }
}
