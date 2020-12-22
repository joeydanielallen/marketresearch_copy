using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class TemplateInstance : ModelBase
    {
        public int Id { get; set; }

        public string Name { get; set; }
        
        public int TemplateId { get; set; }

        public string OriginalTemplateName { get; set; }

        public string PurchaseRequestProcessingSystemId { get; set; }

        public string Nsn { get; set; }

        /// <summary>
        /// Material Management Aggregaton Code and Description
        /// </summary>
        public string Mmac { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemEstimatedValue { get; set; }

        public string UnsuggestedTemplateUseReason { get; set; }

        private DateTime _createdOn;
        public DateTime CreatedOn {

            get { return _createdOn; }
            set
            {
                _createdOn = ValidateUtc(value);
            }
        }

        private DateTime? _completedOn;
        public DateTime? CompletedOn
        {

            get { return _completedOn; }
            set
            {
                _completedOn = ValidateUtc(value);
            }
        }

        public AppUser CreatedByAppUser { get; set; }

        public IEnumerable<AppUser> AppUsers { get; set; }

        public Org Org { get; set; }

        public ServiceType ServiceType { get; set; }

        public SourceType SourceType { get; set; }

        public BidType BidType { get; set; }
        
        public Template Template { get; set; }

        public IEnumerable<TemplateInstanceAnswer> Answers { get; set; }

        public IEnumerable<VendorSearch> SuggestedVendors { get; set; }

    }
}
