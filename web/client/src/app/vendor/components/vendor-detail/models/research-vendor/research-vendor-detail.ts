
import { ResearchVendorContact } from './research-vendor-contact';
import { ResearchVendorPart } from './research-vendor-part';
import { ResearchVendorNote } from './research-vendor-note';

export interface ResearchVendorDetail {
    id: number;
    name: string;
    cageCode: string;
    dunsId: string;
    setAsideId: 0;
    addressLine1: string;
    addressLine2: string;
    city: string;
    stateAbbreviation: string;
    postalCode: string;
    capability: string;
    pastPerformance: string;
    sustainmentId: string;
    setAside: {
      id: 0;
      name: string;
      description: string
    };
    vendorContacts: ResearchVendorContact[];
    vendorParts: ResearchVendorPart[];
    vendorNotes: ResearchVendorNote[];
  }
