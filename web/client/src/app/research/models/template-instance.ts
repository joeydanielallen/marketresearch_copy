
import { VendorSearch } from 'src/app/shared/models/vendor-search';
import { AppUser } from 'src/app/shared/models/app-user';
import { Org } from 'src/app/shared/models/org';
import { Template } from './template';
import { TemplateInstanceAnswer } from 'src/app/research/models/template-instance-answer';


export interface TemplateInstance {
    answers: TemplateInstanceAnswer[];
    suggestedVendors: VendorSearch[];
    id: number;
    name: string;
    templateId: number;
    createdOn: string;
    completedOn: string;
    createdByAppUser: AppUser;
    appUsers: AppUser[];
    org: Org;
    serviceType: number;
    sourceType: number;
    bidType: number;
    originalTemplateName: string;
    template: Template;
    purchaseRequestProcessingSystemId: string;
    nsn: string;
    mmac: string;
    itemQuantity: number;
    itemEstimatedValue:	number;
}

