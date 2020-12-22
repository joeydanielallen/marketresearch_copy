import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorLocationsComponent } from './vendor-locations.component';

describe('VendorLocationsComponent', () => {
  let component: VendorLocationsComponent;
  let fixture: ComponentFixture<VendorLocationsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorLocationsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorLocationsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
