import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorInfoShortComponent } from './vendor-info-short.component';

describe('VendorInfoShortComponent', () => {
  let component: VendorInfoShortComponent;
  let fixture: ComponentFixture<VendorInfoShortComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorInfoShortComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorInfoShortComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
