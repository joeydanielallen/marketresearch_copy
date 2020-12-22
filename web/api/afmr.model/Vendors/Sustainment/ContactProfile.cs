using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class ContactProfile
    {
        public ContactProfile()
        {
            Poc = new ContactProfilePointOfContact();
        }

        public string Url { get; set; }

        public string Phone { get; set; }

        public ContactProfilePointOfContact Poc { get; set; }
    }
}
