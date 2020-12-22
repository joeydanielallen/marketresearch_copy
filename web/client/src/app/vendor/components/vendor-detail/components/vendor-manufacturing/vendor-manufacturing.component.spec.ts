import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorManufacturingComponent } from './vendor-manufacturing.component';

describe('VendorManufacturingComponent', () => {
  let component: VendorManufacturingComponent;
  let fixture: ComponentFixture<VendorManufacturingComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorManufacturingComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorManufacturingComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
