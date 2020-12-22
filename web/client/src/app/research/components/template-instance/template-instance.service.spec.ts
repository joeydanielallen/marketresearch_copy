import { TestBed } from '@angular/core/testing';

import { TemplateInstanceService } from './template-instance.service';

describe('TemplateInstanceService', () => {
  let service: TemplateInstanceService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TemplateInstanceService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
