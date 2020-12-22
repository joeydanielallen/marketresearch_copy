
import { TemplateQuestion } from './template-questions';
import { TemplateSectionGroup } from './template-section-group';

export interface TemplateSection {
    id: number;
    templateId: number;
    sectionId: number;
    name: string;
    description: string;
    hasQuestionGrouping: boolean;
    systemControlTypeId: number;
    orderIndex: number;
    templateSectionGroupId: number;
    templateSectionGroup: TemplateSectionGroup;
    questions: TemplateQuestion[];
}
