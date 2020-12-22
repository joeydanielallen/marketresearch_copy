import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-manufacturing',
  templateUrl: './vendor-manufacturing.component.html',
  styleUrls: ['./vendor-manufacturing.component.css']
})
export class VendorManufacturingComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorManufacturing;

  constructor() { }

  ngOnInit(): void {
  }

}
