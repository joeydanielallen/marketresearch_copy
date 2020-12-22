using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class ContactAgent : Location
    {
        new private string Congress_district { get; set; }

        public string Name { get; set; }
    }
}
