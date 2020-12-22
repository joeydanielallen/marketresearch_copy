import { Component, OnInit, OnDestroy } from '@angular/core';
import { Router } from '@angular/router';
import { Subscription } from 'rxjs';
import { Vendor } from 'src/app/shared/models/vendor';
import { VendorService } from 'src/app/shared/services/vendor.service';

@Component({
  selector: 'app-recent-vendors',
  templateUrl: './recent-vendors.component.html',
  styleUrls: ['./recent-vendors.component.css']
})
export class RecentVendorsComponent implements OnInit, OnDestroy {

  private subscriptions = new Subscription();

  isLoading = true;
  hasLoadError = false;
  recents: Vendor[] = [];


  constructor(
    private vendorService: VendorService,
    private router: Router) { }

  ngOnInit(): void {
    this.getRecents();
  }

  ngOnDestroy(): void {
    this.subscriptions.unsubscribe();
  }

  navVendDetail(vendor: Vendor): void {

    let mrId = '';
    let susId = '';

    if (vendor.id) {
      // this is for the nameCageOrDuns search
      mrId = vendor.id.toString();
      susId = vendor.sustainmentId;
    }

    this.router.navigate([ `./vendor/detail/${mrId ?? susId}/${susId}`]);
  }

  getRecents(): void {
    this.hasLoadError = false;

    this.subscriptions.add(
      this.vendorService.getRecentlyViewedVendors(5).subscribe(res => {
        this.isLoading = false;
        this.recents = res;
      },
      error => {
        this.isLoading = false;
        this.hasLoadError = true;
      })
    );

  }
}
