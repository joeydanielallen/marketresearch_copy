export class UserAccount {
    appKeyExpiration = new Date(0);
    appKey = '';
    permissionClaimValues: string[] = [];
    userAccountId = 0;
    email = '';
    expiresOnUtc = new Date(0);
    isLockedOut = false;
    userName = '';
    firstName = '';
    lastName = '';
    modifiedOnUtc = new Date(0);
}
