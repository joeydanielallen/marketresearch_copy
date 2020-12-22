import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { InitiateResearchComponent } from './initiate-research.component';

describe('InitiateResearchComponent', () => {
  let component: InitiateResearchComponent;
  let fixture: ComponentFixture<InitiateResearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ InitiateResearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(InitiateResearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
