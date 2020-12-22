using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class StartResearchRequest
    {
        public InitiateResponse InitiateResponse { get; set; }

        public FormTemplate FormTemplate { get; set; }

        public string RemainingTemplateReason { get; set; }
    }
}
