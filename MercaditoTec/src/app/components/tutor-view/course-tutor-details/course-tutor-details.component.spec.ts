import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseTutorDetailsComponent } from './course-tutor-details.component';

describe('CourseTutorDetailsComponent', () => {
  let component: CourseTutorDetailsComponent;
  let fixture: ComponentFixture<CourseTutorDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseTutorDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseTutorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });


});
