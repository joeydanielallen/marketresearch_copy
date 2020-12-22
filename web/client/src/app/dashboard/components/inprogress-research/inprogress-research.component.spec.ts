import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InprogressResearchComponent } from './inprogress-research.component';

describe('InprogressResearchComponent', () => {
  let component: InprogressResearchComponent;
  let fixture: ComponentFixture<InprogressResearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InprogressResearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InprogressResearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
