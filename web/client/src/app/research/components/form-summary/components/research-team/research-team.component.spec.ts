import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { ResearchTeamComponent } from './research-team.component';

describe('ResearchTeamComponent', () => {
  let component: ResearchTeamComponent;
  let fixture: ComponentFixture<ResearchTeamComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ ResearchTeamComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(ResearchTeamComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
