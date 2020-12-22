import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-industry',
  templateUrl: './vendor-industry.component.html',
  styleUrls: ['./vendor-industry.component.css']
})
export class VendorIndustryComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorIndustry;

  constructor() { }

  ngOnInit(): void {
  }

}
