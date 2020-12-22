using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class IndustryClassification
    {
        public IndustryClassification()
        {
            Naics = new List<string>();
        }

        public string Naics_primary { get; set; }

        public IEnumerable<string> Naics { get; set; }
    }
}
