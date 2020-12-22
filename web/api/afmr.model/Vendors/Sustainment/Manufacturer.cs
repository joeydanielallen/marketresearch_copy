using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Manufacturer
    {
        public Manufacturer()
        {
            Materials = new List<string>();
            Tolerances = new List<string>();
            Files = new List<string>();
        }

        public IEnumerable<string> Materials { get; set; }
        public IEnumerable<string> Tolerances { get; set; }
        public bool? Engines { get; set; }
        public string First_year { get; set; }
        public IEnumerable<string> Files { get; set; }
        public string Capabilities { get; set; }

    }
}
