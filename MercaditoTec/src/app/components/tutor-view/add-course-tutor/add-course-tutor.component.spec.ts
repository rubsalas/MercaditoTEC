import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddCourseTutorComponent } from './add-course-tutor.component';

describe('AddCourseTutorComponent', () => {
  let component: AddCourseTutorComponent;
  let fixture: ComponentFixture<AddCourseTutorComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddCourseTutorComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddCourseTutorComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });


});
