using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Contacts
    {
        public Contacts()
        {
            Phone = new List<string>();
            Fax = new List<string>();
            Profile = new ContactProfile();
            Agent = new ContactAgent();
            Other = new List<ContactOther>();
        }

        public IEnumerable<string> Phone { get; set; }

        public IEnumerable<string> Fax { get; set; }

        public ContactProfile Profile { get; set; }

        public ContactAgent Agent { get; set; }

        public IEnumerable<ContactOther> Other { get; set; }
    }
}
