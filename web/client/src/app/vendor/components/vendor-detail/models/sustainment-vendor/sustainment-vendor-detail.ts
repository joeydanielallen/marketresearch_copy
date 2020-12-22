import { Address } from './address';
import { POPAddress } from './pop-address';

export interface SustainmentVendorDetail {
    vendor_id: string;
    names: {
        legal: string;
        profile: string;
        dbAs: string[];
        akAs: string[];
    };
    ids: {
        duns: string;
        cage: string;
        ein: string;
        state_number: {
            state: string;
            number: string;
        };
    };
    locations: {
        incorporated: Address;
        billings: Address;
        profile: {
            physical: Address;
            mail: Address;
        };
        others: Address[];
        places_of_performances: POPAddress[];
    };
    types: {
        sam: string[];
        sustainment: string[];
        cage: string[];
    };
    contacts: {
        phone: string[];
        fax: string[];
        profile: {
            url: string;
            phone: string;
            poc: {
                name: string;
                phone: string;
                email: string;
            };
        };
        agent: {
            name: string;
            address_line1: string;
            address_line2: string;
            country: string;
            city: string;
            state: string;
            zip: string;
        };
        other: [
            {
                name: string;
                email: string;
            }
        ];
    };
    validations: {
        state: {
            formation_date: string;
        };
        cage: {
            status: string;
            established: string;
            updated: string;
        };
    };
    size: {
        employees: number;
        shop_size: number;
        num_machines: number;
    };
    sam_files: {
        far: string;
        dfar: string;
    };
    certifications: [
        {
            name: string;
            certifier: string;
            date: string;
            expiration: string;
            file: string;
            types: {};
        }
    ];
    industries: {
        naics_primary: string;
        naics: string[];
    };
    manufacturing: {
        materials: string[];
        tolerances: string[];
        engines: true;
        first_year: string;
        files: string[];
        capabilities: string;
    };
    profile: {
        created: string;
        updated: {
            date: string;
            by: string;
        };
    };

}
