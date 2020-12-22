using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class LocationProfile
    {
        public LocationProfile()
        {
            Mail = new Location();
            Physical = new Location();
        }

        public Location Physical { get; set; }

        public Location Mail { get; set; }
    }
}
