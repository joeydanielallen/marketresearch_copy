using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model
{
    public interface IConfig
    {
        string OdysseusApiUrl { get; set; }

        string OdysseusApiKey { get; set; }

        string SustainmentApiNsnSearchUrl { get; set; }

        string SustainmentApiNsnToVendorUrl { get; set; }

        string SustainmentPdfServiceUrl { get; set; }

        string SustainmentPdfBlobConnectionString { get; set; }

        string SustainmentPdfBlobContainer { get; set; }

        string SustainmentVendorDetailApiUrl { get; set; }
    }
}
