import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentPartsComponent } from './recent-parts.component';

describe('RecentPartsComponent', () => {
  let component: RecentPartsComponent;
  let fixture: ComponentFixture<RecentPartsComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentPartsComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentPartsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
