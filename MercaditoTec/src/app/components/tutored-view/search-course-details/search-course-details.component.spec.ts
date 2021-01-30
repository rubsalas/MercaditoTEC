import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SearchCourseDetailsComponent } from './search-course-details.component';

describe('SearchCourseDetailsComponent', () => {
  let component: SearchCourseDetailsComponent;
  let fixture: ComponentFixture<SearchCourseDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SearchCourseDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(SearchCourseDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
