import { TestBed } from '@angular/core/testing';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';
import { TutorService } from './tutor.service';

describe('TutorService', () => {
  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule], 
    providers: [TutorService]
  }));

  
   
   /*
it('should be created', () => {
    const service: TutorService = TestBed.get(TutorService);
    expect(service).toBeTruthy();
   });
   
   it('should have getData function', () => {
    const service: StudentService = TestBed.get(StudentService);
    expect(service.getData).toBeTruthy();
   });*/
});
