import { TestBed } from '@angular/core/testing';

import { TutoredService } from './tutored.service';

describe('TutoredService', () => {
  let service: TutoredService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(TutoredService);
  });

});
