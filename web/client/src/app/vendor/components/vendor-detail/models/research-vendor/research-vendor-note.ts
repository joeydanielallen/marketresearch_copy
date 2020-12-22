
export interface ResearchVendorNote {
    id: number;
    vendorId: number;
    title: string;
    note: string;
    savedOn: Date;
    createdByAppUser: {
        userAccountId: number;
        firstName: string;
        lastName: string;
    };
}
