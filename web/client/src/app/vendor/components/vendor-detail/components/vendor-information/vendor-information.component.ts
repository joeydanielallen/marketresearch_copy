import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-vendor-information',
  templateUrl: './vendor-information.component.html',
  styleUrls: ['./vendor-information.component.css']
})
export class VendorInformationComponent implements OnInit {

  @Input() mrVendorDetail;
  @Input() mrDataLoading;

  constructor() { }

  ngOnInit(): void {
  }

}
