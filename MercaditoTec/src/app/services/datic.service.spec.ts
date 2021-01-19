import { TestBed } from '@angular/core/testing';

import { DaticService } from './datic.service';

describe('DaticService', () => {
  let service: DaticService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DaticService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
