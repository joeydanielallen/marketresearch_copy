import { Component, OnInit, Input } from '@angular/core';

@Component({
  selector: 'app-vendor-contacts',
  templateUrl: './vendor-contacts.component.html',
  styleUrls: ['./vendor-contacts.component.css']
})
export class VendorContactsComponent implements OnInit {

  @Input() mrVendorDetail;
  @Input() mrDataLoading;

  constructor() { }

  ngOnInit(): void {
  }

}
