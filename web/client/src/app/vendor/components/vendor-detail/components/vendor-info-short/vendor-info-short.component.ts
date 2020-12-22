import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-info-short',
  templateUrl: './vendor-info-short.component.html',
  styleUrls: ['./vendor-info-short.component.css']
})
export class VendorInfoShortComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorInfo;
  @Input() susVendorIndustry;

  constructor() { }

  ngOnInit(): void {
  }

}
