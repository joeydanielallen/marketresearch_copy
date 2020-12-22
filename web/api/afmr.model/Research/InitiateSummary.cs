using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class InitiateSummary
    {
        public string Nsn { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemEstimatedValue {get;set;}

        public decimal EstimatedValue
        {
            get
            {
                return ItemQuantity * ItemEstimatedValue;
            }
        }

        public string ServiceTypeName { get; set; }

        public string SourceTypeName { get; set; }
        
        public string PurchaseRequestProcessingSystemId { get; set; }
    }
}
