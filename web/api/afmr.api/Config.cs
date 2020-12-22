using afmr.model;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace afmr.api
{
    public class Config : IAppConfig, IConfig
    {
        public Config(IConfigurationRoot configRoot)
        {
            SessionPersistenceDays = configRoot.GetValue<int?>(nameof(SessionPersistenceDays)) ?? 7;
            OdysseusApiUrl = configRoot.GetValue<string>(nameof(OdysseusApiUrl));
            OdysseusApiKey = configRoot.GetValue<string>(nameof(OdysseusApiKey));
            SustainmentApiNsnSearchUrl = configRoot.GetValue<string>(nameof(SustainmentApiNsnSearchUrl));
            SustainmentApiNsnToVendorUrl = configRoot.GetValue<string>(nameof(SustainmentApiNsnToVendorUrl));
            SustainmentPdfServiceUrl = configRoot.GetValue<string>(nameof(SustainmentPdfServiceUrl));
            SustainmentPdfBlobConnectionString = configRoot.GetValue<string>(nameof(SustainmentPdfBlobConnectionString));
            SustainmentPdfBlobContainer = configRoot.GetValue<string>(nameof(SustainmentPdfBlobContainer));
            SustainmentVendorDetailApiUrl = configRoot.GetValue<string>(nameof(SustainmentVendorDetailApiUrl));
        }

        public int SessionPersistenceDays  { get; set; }

        public string OdysseusApiUrl { get; set; }

        public string OdysseusApiKey { get; set; }

        public string SustainmentApiNsnSearchUrl { get; set; }

        public string SustainmentApiNsnToVendorUrl { get; set; }

        public string SustainmentPdfServiceUrl { get; set; }

        public string SustainmentPdfBlobConnectionString { get; set; }

        public string SustainmentPdfBlobContainer { get; set; }

        public string SustainmentVendorDetailApiUrl { get; set; }
    }
}
