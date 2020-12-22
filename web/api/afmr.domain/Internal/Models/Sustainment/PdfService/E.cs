using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.domain.Internal.Models.Sustainment.PdfService
{
    public class E
    {
        public string general { get; set; }
        public string large { get; set; }
        public string edu { get; set; }
        public string nonprofit { get; set; }
        public string small { get; set; }
        public string govt { get; set; }
        public string other { get; set; }
        public string sdb { get; set; }
        public string edwosb { get; set; }
        public string vet { get; set; }

        [JsonProperty("8a")]
        public string Eighta { get; set; }
        public string hub { get; set; }
        public string wosb { get; set; }
        public string sdvosb { get; set; }
        public string native { get; set; }
        public List<Vendor> vendors { get; set; }
    }
}
