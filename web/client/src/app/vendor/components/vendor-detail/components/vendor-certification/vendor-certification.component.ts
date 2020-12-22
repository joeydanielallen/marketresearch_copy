import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-vendor-certification',
  templateUrl: './vendor-certification.component.html',
  styleUrls: ['./vendor-certification.component.css']
})
export class VendorCertificationComponent implements OnInit {

  @Input() susDataLoading;
  @Input() susVendorCertification;

  constructor() { }

  ngOnInit(): void {
  }

  navToCertFile(file: string): void {
    console.log('New window to ' + file);
    window.open(file, '_blank');
  }

}
