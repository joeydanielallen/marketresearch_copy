import { Vendor } from '../../shared/models/vendor';
import { VendorNote } from './vendor-note';

export interface VendorDetail extends Vendor {
    capability: string;
    pastPerformance: string;
    setAsideId: number;
    setAside: any; // TODO create model
    vendorNotes: VendorNote[];
    vendorContacts: any[]; // TODO create model
    vendorParts: any[]; // TODO create model
}
