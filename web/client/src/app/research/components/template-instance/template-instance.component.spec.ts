import { async, ComponentFixture, TestBed } from '@angular/core/testing';

import { TemplateInstanceComponent } from './template-instance.component';

describe('TemplateInstanceComponent', () => {
  let component: TemplateInstanceComponent;
  let fixture: ComponentFixture<TemplateInstanceComponent>;

  beforeEach(async(() => {
    TestBed.configureTestingModule({
      declarations: [ TemplateInstanceComponent ]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(TemplateInstanceComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
