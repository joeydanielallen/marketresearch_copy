using afmr.data.Models.Security;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace afmr.data.Models.Template
{
    public class TemplateInstance : IEntity
    {
        public int Id { get; set; }

        public int TemplateId { get; set; }

        public int CreatedByUserAccountId { get; set; }

        public string Name { get; set; }

        public string OriginalTemplateName { get; set; }

        public int OrgId { get; set; }

        public string PurchaseRequestProcessingSystemId { get; set; }

        public string Nsn { get; set; }

        public int ItemQuantity { get; set; }

        public decimal ItemEstimatedValue { get; set; }

        public int BidTypeId { get; set; }

        public int SourceTypeId { get; set; }

        public int ServiceTypeId { get; set; }

        public string UnsuggestedTemplateUseReason { get; set; }

        public DateTime CreatedOnUtc { get; set; }

        public DateTime? CompletedOnUtc { get; set; }

        [ForeignKey(nameof(ServiceTypeId))]
        public ServiceType ServiceType { get; set; }

        [ForeignKey(nameof(SourceTypeId))]
        public SourceType SourceType { get; set; }

        [ForeignKey(nameof(BidTypeId))]
        public BidType BidType { get; set; }
        
        public IEnumerable<TemplateInstanceUser> TemplateUsers { get; set; }

        [ForeignKey(nameof(CreatedByUserAccountId))]
        public UserAccount CreatedByUser { get; set; }

        [ForeignKey(nameof(OrgId))]
        public Org Org { get; set; }

        [ForeignKey(nameof(TemplateId))]
        public Template Template { get; set; }

        public IList<TemplateInitiateVendor> TemplateInitiateVendors { get; set; } = new List<TemplateInitiateVendor>();

        public IEnumerable<TemplateInstanceAnswer> TemplateInstanceAnswers { get; set; } = new List<TemplateInstanceAnswer>();
    }
}
