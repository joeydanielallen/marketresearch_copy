import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorCertificationComponent } from './vendor-certification.component';

describe('VendorCertificationComponent', () => {
  let component: VendorCertificationComponent;
  let fixture: ComponentFixture<VendorCertificationComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorCertificationComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorCertificationComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
