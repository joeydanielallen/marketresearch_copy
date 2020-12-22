import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorIndustryComponent } from './vendor-industry.component';

describe('VendorIndustryComponent', () => {
  let component: VendorIndustryComponent;
  let fixture: ComponentFixture<VendorIndustryComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorIndustryComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorIndustryComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
