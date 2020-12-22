using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class InitiateRequest
    {
        public string Nsn { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemEstimatedValue { get; set; }

        public string PurchaseRequestProcessingSystemId { get; set; }

        public ServiceType ServiceType { get; set; }

        public SourceType SourceType { get; set; }

        public decimal TotalEstimatedValue
        {
            get
            {
                return ItemQuantity * ItemEstimatedValue;
            }
        }
    }
}
