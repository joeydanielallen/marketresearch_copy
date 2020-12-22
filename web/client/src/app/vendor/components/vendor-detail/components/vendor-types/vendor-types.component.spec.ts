import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorTypesComponent } from './vendor-types.component';

describe('VendorTypesComponent', () => {
  let component: VendorTypesComponent;
  let fixture: ComponentFixture<VendorTypesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorTypesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorTypesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
