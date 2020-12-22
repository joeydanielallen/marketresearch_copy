
import { VendorSummary } from 'src/app/shared/models/vendor-summary';

export interface InitiateAward {
    vendor: VendorSummary;
    partNumber: string;
}
