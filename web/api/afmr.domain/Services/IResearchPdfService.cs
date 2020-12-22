using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace afmr.domain.Services
{
    public interface IResearchPdfService
    {
        Stream GetResearchFormPdf(int templateInstanceId);
    }
}
