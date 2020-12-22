import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchResearchComponent } from './search-research.component';

describe('SearchResearchComponent', () => {
  let component: SearchResearchComponent;
  let fixture: ComponentFixture<SearchResearchComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ SearchResearchComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchResearchComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
