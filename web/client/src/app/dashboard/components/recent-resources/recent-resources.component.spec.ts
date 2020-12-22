import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentResourcesComponent } from './recent-resources.component';

describe('RecentResourcesComponent', () => {
  let component: RecentResourcesComponent;
  let fixture: ComponentFixture<RecentResourcesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentResourcesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentResourcesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
