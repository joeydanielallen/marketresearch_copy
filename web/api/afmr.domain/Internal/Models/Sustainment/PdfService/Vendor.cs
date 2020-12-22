using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace afmr.domain.Internal.Models.Sustainment.PdfService
{
    public class Vendor
    {
        public string name { get; set; }

        [JsonProperty("CAGE")]
        public string CAGE { get; set; }
        public string group { get; set; }
        public string loc { get; set; }
        public string poc { get; set; }
        public string caps { get; set; }
        public string past { get; set; }
    }
}
