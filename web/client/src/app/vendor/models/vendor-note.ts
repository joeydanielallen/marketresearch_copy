import { UserAccountName } from '../../shared/models/user-account-name';

export class VendorNote {
    id = 0;
    vendorId = 0;
    title = '';
    note = '';
    savedOn = new Date();
    createdByAppUser: UserAccountName;
}
