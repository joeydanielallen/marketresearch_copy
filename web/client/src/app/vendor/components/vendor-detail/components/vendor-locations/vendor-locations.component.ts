import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-locations',
  templateUrl: './vendor-locations.component.html',
  styleUrls: ['./vendor-locations.component.css']
})
export class VendorLocationsComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorLocations;

  constructor() { }

  ngOnInit(): void {
  }



}
