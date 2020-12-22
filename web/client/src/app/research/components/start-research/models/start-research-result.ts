import { KeyValue } from 'src/app/shared/models/key-value';
import { InitiateResearch } from 'src/app/research/models/initiate-research';

export class StartResearchResult {
    initiateResearch: InitiateResearch;
    processingResults: string[] = [];
    proposedTemplateIds: number[] = [];
    availableTemplates: KeyValue[] = [];
}
