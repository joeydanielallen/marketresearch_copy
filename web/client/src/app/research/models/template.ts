
import { Org } from 'src/app/shared/models/org';
import { TemplateSection } from './template-section';


export interface Template {
    id: number;
    name: string;
    description: string;
    minEstimatedValue: number;
    maxEstimatedValue: number;
    isActive: boolean;
    bidTypes: number[];
    orgs: Org[];
    serviceTypes: number[];
    sourceTypes: number[];
    sections: TemplateSection[];
}
