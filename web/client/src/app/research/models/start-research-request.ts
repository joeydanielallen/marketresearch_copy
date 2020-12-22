import { InitiateResponse } from './initiate-response';
import { ResearchTemplate } from './research-template';

export interface StartResearchRequest{
    initiateResponse: InitiateResponse;
    formTemplate: ResearchTemplate;
    remainingTemplateReason: string;
}
