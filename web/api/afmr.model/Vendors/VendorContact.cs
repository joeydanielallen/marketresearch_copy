using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors
{
   public  class VendorContact : ModelBase
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
    }
}
