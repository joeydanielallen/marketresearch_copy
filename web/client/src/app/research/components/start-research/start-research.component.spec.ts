import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { StartResearchComponent } from './start-research.component';

describe('StartResearchComponent', () => {
  let component: StartResearchComponent;
  let fixture: ComponentFixture<StartResearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ StartResearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(StartResearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
