import { VendorSummary } from 'src/app/shared/models/vendor-summary';

export interface PriorResearchSummary {
    templateInstanceId: number;
    templateName: string;
    completionDate: Date;
    purchaseRequestProcessingSystemId: string;
    itemQuantity: number;
    itemEstimatedValue: number;
    estimatedValue: number;
    serviceTypeName: string;
    sourceTypeName: string;
    orgName: string;
    vendors: VendorSummary[];
    bidTypeName: string;
}
