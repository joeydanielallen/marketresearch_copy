
import { InitiateSummary } from './initiate-summary';
import { InitiateNsn } from './initiate-nsn';
import { InitiateAward } from './initiate-award';
import { PriorResearchSummary } from './prior-research-summary';
import { ResearchTemplate } from './research-template';
import { SearchQueueResponse } from './search-queue-response';
import { VendorSearch } from 'src/app//shared/models/vendor-search';

export interface InitiateResponse {
    modelHash: string;
    initiateSummary: InitiateSummary;
    initiateNsn: InitiateNsn;
    proposedBidType: number;
    awards: InitiateAward[];
    suggestedVendors: VendorSearch[];
    priorResearchSummaries: PriorResearchSummary[];
    proposedTemplates: ResearchTemplate[];
    remainingTemplates: ResearchTemplate[];
    searchQueueResponse?: SearchQueueResponse;
  }
