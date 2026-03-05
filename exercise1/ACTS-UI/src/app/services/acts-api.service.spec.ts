import { TestBed } from '@angular/core/testing';

import { ActsAPIService } from './acts-api.service';

describe('ActsAPIService', () => {
  let service: ActsAPIService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(ActsAPIService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
