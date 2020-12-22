import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-types',
  templateUrl: './vendor-types.component.html',
  styleUrls: ['./vendor-types.component.css']
})
export class VendorTypesComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorTypes;

  constructor() { }

  ngOnInit(): void {
  }

  formatType(type: string): string {
    return type.replace(/_/g, ' ');
  }

}
