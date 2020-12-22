using afmr.model.Account;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors
{
    public class VendorNote : ModelBase
    {
        public int Id { get; set; }

        public int VendorId { get; set; }

        public string Title { get; set; }

        public string Note { get; set; }

        private DateTime _savedOn;
        public DateTime SavedOn
        {
            get { return _savedOn; }
            set
            {
                _savedOn = ValidateUtc(value);
            }
        }

        public UserAccountName CreatedByAppUser { get; set; }
    }
}
