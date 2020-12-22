using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Names
    {
        public Names()
        {
            DBAs = new List<string>();
            AKAs = new List<string>();
        }
        public string Legal { get; set; }
        public string Profile { get; set; }
        public IEnumerable<string> DBAs { get; set; }
        public IEnumerable<string> AKAs { get; set; }
    }
}
