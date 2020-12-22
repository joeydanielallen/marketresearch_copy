using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Vendors.Sustainment
{
    public class Certification
    {
        public string Name { get; set; }

        public string Certifier { get; set; }

        public string Date { get; set; }

        public string Expiration { get; set; }

        public string File { get; set; }

        public CertificationTypes Types { get; set; }
    }
}
