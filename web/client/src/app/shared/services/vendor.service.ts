import { Injectable } from '@angular/core';

import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { UserService } from 'src/app/shared/services/user.service';
import { NewVendorNote } from 'src/app/vendor/models/new-vendor-note';
import { VendorDetail } from 'src/app/vendor/models//vendor-detail';
import { VendorSearch } from 'src/app/shared/models/vendor-search';
import { Vendor } from 'src/app/shared/models/vendor';

import { ResearchVendorDetail } from '../../vendor/components/vendor-detail/models/research-vendor/research-vendor-detail';
import { SustainmentVendorDetail } from '../../vendor/components/vendor-detail/models/sustainment-vendor/sustainment-vendor-detail';

@Injectable({
  providedIn: 'root'
})
export class VendorService {

  constructor(
    private httpClient: HttpClient,
    private userService: UserService
  ) { }


  getMRVendorDetail(mrVendorId: string): Observable<ResearchVendorDetail> {
    return this.httpClient.get<ResearchVendorDetail>(this.userService.originUrl + `Vendor/${mrVendorId}`);
  }

  addVendorNote(note: NewVendorNote): Observable<number> {
    return this.httpClient.post<number>(this.userService.originUrl + `VendorNote/`, note);
  }

  removeVendorNote(noteId: number): Observable<void> {
    return this.httpClient.delete<void>(this.userService.originUrl + `VendorNote/${noteId}`);
  }

  searchVendorsByOther(nameOrCageOrDuns: string): Observable<VendorSearch[]> {
    return this.httpClient.get<VendorSearch[]>(this.userService.originUrl + `VendorSearch/${nameOrCageOrDuns}`);
  }

  searchVendorsByNSN(nsn: string) {
    return this.httpClient.get<any[]>(this.userService.originUrl + `VendorSearchByNSN/${nsn.substring(0, 13)}`);
  }

  getSustainmentVendorDetails(susVendorId: string): Observable<SustainmentVendorDetail> {
    return this.httpClient.get<any>(this.userService.originUrl + `VendorDetail/${susVendorId}`);
  }

  getRecentlyViewedVendors(count?: number): Observable<Vendor[]> {
    return this.httpClient.get<Vendor[]>(this.userService.originUrl + 'RecentVendor?count=' + (count ?? 5));
  }
}
