import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { RecentStrategiesComponent } from './recent-strategies.component';

describe('RecentStrategiesComponent', () => {
  let component: RecentStrategiesComponent;
  let fixture: ComponentFixture<RecentStrategiesComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ RecentStrategiesComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(RecentStrategiesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
