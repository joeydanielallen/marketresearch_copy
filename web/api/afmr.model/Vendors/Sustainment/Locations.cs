using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Locations
    {
        public Locations ()
        {
            Others = new List<Location>();
            Places_of_performances = new List<LocationPlace>();
            Profile = new LocationProfile();
        }

        public Location Incorporated { get; set; }

        public Location Billings { get; set; }

        public LocationProfile Profile { get; set; }

        public IEnumerable<Location> Others { get; set; }

        public IEnumerable<LocationPlace> Places_of_performances { get; set; }
    }
}
