using System;
using System.Collections.Generic;

namespace afmr.model.Research
{
    public class PriorResearchSummary : ModelBase
    {
        public int TemplateInstanceId { get; set; }

        public string TemplateName { get; set; }

        private DateTime? _completionDate;
        public DateTime? CompletionDate
        {
            get { return _completionDate; }
            set { _completionDate = ValidateUtc(value); }
        }

        public string PurchaseRequestProcessingSystemId { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemEstimatedValue { get; set; }

        public decimal EstimatedValue
        {
            get
            {
                return ItemQuantity * ItemEstimatedValue;
            }
        }

        public string ServiceTypeName { get; set; }

        public string SourceTypeName { get; set; }

        public string OrgName { get; set; }

        public IEnumerable<VendorSummary> Vendors  { get; set; }

        public string BidTypeName { get; set; }
}
}