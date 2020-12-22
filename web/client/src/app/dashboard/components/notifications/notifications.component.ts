import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Vendor } from 'src/app/shared/models/vendor';
import { VendorService } from 'src/app/shared/services/vendor.service';

@Component({
  selector: 'app-notifications',
  templateUrl: './notifications.component.html',
  styleUrls: ['./notifications.component.css']
})
export class NotificationsComponent implements OnInit {
  isLoading = true;
  hasLoadError = false;
  notifications = [];


  constructor(
    private vendorService: VendorService,
    private router: Router) { }

  ngOnInit(): void {
    this.getRecents();
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

    this.notifications = [
      {
        title: 'New Strategy Added',
        description: 'Strategy Title by Steven Gerard'
      },
      {
        title: 'New Message',
        description: 'James Milner sent you a message'
      },
      {
        title: 'Strategy Updated',
        description: 'Kimberly Strak edited Strategy Title'
      }
    ];

    this.isLoading = false;

    // this.vendorService.getRecentlyViewedVendors(5).subscribe(res => {
    //   this.isLoading = false;
    //   this.recents = res;
    // },
    // error => {
    //   this.isLoading = false;
    //   this.hasLoadError = true;
    // });


  }
}
