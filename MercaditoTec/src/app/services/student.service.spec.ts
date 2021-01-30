import { TestBed } from '@angular/core/testing';
import { StudentService } from './student.service';
import { HttpClientTestingModule, HttpTestingController } from '@angular/common/http/testing';
import {HttpClientModule} from '@angular/common/http';

describe('StudentService', () => {

  beforeEach(() => TestBed.configureTestingModule({
    imports: [HttpClientTestingModule], 
    providers: [StudentService]
  }));

  
   
   /*

   it('should have getData function', () => {
    const service: StudentService = TestBed.get(StudentService);
    expect(service.getData).toBeTruthy();
   });
   
   it('should be created', () => {
    const service: StudentService = TestBed.get(StudentService);
    expect(service).toBeTruthy();
   });
   */
});