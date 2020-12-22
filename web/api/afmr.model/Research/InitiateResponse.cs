using afmr.model.Vendors;
using System;
using System.Collections.Generic;
using System.Text;

namespace afmr.model.Research
{
    public class InitiateResponse
    {
        public string ModelHash { get; set; }

        public InitiateSummary InitiateSummary { get; set; }

        public InitiateNsn InitiateNsn { get; set; }

        public BidType ProposedBidType { get; set; }

        public IEnumerable<InitiateAward> Awards { get; set; }

        public IEnumerable<VendorSearch> SuggestedVendors { get; set; }

        public IEnumerable<PriorResearchSummary> PriorResearchSummaries { get; set; }

        public IEnumerable<FormTemplate> ProposedTemplates { get; set; }

        public IEnumerable<FormTemplate> RemainingTemplates { get; set; }

        /// <summary>
        /// This describes the state of finding an NSN if not populated already in system.
        /// If null, other objects should be populated.
        /// If not null, other objects should not be populated except for InitiateSummary.
        /// </summary>
        public SearchQueueResponse SearchQueueResponse { get; set; }
    }
}
