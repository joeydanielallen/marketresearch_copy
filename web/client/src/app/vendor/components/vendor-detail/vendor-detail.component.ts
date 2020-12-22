import { Component, OnInit, OnDestroy } from '@angular/core';

import { VendorService } from '../../../shared/services/vendor.service';
import { ActivatedRoute, Params } from '@angular/router';
import { NotifyService } from 'src/app/shared/services/notify.service';

import { ResearchVendorDetail } from './models/research-vendor/research-vendor-detail';
import { SustainmentVendorDetail } from './models/sustainment-vendor/sustainment-vendor-detail';
import { Subscription } from 'rxjs';






@Component({
  selector: 'app-vendor-detail',
  templateUrl: './vendor-detail.component.html',
  styleUrls: ['./vendor-detail.component.css']
})
export class VendorDetailComponent implements OnInit, OnDestroy {

  constructor(
    private vendorService: VendorService,
    private route: ActivatedRoute,
    private notifyService: NotifyService
  ) { }

  private subsriptions = new Subscription();

  mrVendorId: string;
  susVendorId: string;

  mrVendorDetail: ResearchVendorDetail;
  susVendorDetail: SustainmentVendorDetail;

  mrDataLoading = false;
  susDataLoading = false;


  ngOnInit(): void {

    this.mrVendorId = this.route.snapshot.params.mrId;
    this.susVendorId = this.route.snapshot.params.susId;

    console.log(this.mrVendorId);

    // if(this.mrVendorId !== "null") {
    this.getMRVendorDetail(this.mrVendorId ?? this.susVendorId);
    // } else {this.mrVendorDetail = {}; }
    if (this.susVendorId !== 'null') { this.getSusVendorDetail(this.susVendorId); } else {this.susVendorDetail = null; }

  }

  ngOnDestroy(): void {
    this.subsriptions.unsubscribe();
  }


  getMRVendorDetail(mrVendorId: string): void {
    this.mrDataLoading = true;

    this.subsriptions.add(
      this.vendorService.getMRVendorDetail(mrVendorId).subscribe(res => {
        console.log(res);

        this.mrVendorDetail = res;
        this.mrDataLoading = false;

      }, (e) => {
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
        console.log(JSON.stringify(e));

        this.mrDataLoading = false;
        this.mrVendorDetail = null;
      })
    );


  }

  getSusVendorDetail(susVendorId: string): void {
    this.susDataLoading = true;

    this.subsriptions.add(
      this.vendorService.getSustainmentVendorDetails(susVendorId).subscribe((res) => {
        console.log(res);

        this.susVendorDetail = res;

        if (this.susVendorDetail.size === null) {
          this.susVendorDetail.size = {
            employees: null,
            num_machines: null,
            shop_size: null
          };
        }

        if (this.susVendorDetail.names.dbAs) {
          this.susVendorDetail.names.dbAs = this.susVendorDetail.names.dbAs.filter((dba) => {
            if (dba.length === 0) {
              return false;
            } else {
              return true;
            }
          });
        }

        this.susDataLoading = false;

      }, (e) => {
        this.notifyService.show('An error occurred. Please try again.', {classname: 'alert-danger'});
        console.log(JSON.stringify(e));

        this.susDataLoading = false;
        this.susVendorDetail = null;
      })
    );

  }



  refreshVendor(): void {
    this.getMRVendorDetail(this.mrVendorId);
  }


}
