using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Types
    {
        public Types ()
        {
            Sam = new List<string>();
            Sustainment = new List<string>();
            Cage = new List<string>();
        }

        public IEnumerable<string> Sam { get; set; }
        public IEnumerable<string> Sustainment { get; set; }

        public IEnumerable<string> Cage { get; set; }
    }
}
