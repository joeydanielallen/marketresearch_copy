import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { VendorNotesComponent } from './vendor-notes.component';

describe('VendorNotesComponent', () => {
  let component: VendorNotesComponent;
  let fixture: ComponentFixture<VendorNotesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ VendorNotesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(VendorNotesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
