
export interface InitiateNsn {
    nsn: string; // 9 or 13 digit number
    fsgName: string; // fed supply group desc
    fscName: string; // fed supply class desc
    mmac: string; // Air Force logistic center relationship desc
    name: string;
}
