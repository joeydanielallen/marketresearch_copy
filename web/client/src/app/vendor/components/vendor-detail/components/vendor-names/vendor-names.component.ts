import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-names',
  templateUrl: './vendor-names.component.html',
  styleUrls: ['./vendor-names.component.css']
})
export class VendorNamesComponent implements OnInit {

  @Input() susDataLoading;
  @Input() mrVendorName;
  @Input() susVendorNames;
  @Input() susVendorIds;

  constructor() { }

  ngOnInit(): void {
  }

}
