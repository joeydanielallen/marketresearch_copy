import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorNamesComponent } from './vendor-names.component';

describe('VendorNamesComponent', () => {
  let component: VendorNamesComponent;
  let fixture: ComponentFixture<VendorNamesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorNamesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorNamesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
