import { VendorSummary } from './vendor-summary';

export interface Vendor extends VendorSummary {
    id: number;
    sustainmentId: string;
    addressLine1: string;
    addressLine2: string;
    city: string;
    stateAbbreviation: string;
    postalCode: string;
}
