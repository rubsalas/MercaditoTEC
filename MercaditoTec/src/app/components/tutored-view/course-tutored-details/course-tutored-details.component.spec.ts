import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CourseTutoredDetailsComponent } from './course-tutored-details.component';

describe('CourseTutoredDetailsComponent', () => {
  let component: CourseTutoredDetailsComponent;
  let fixture: ComponentFixture<CourseTutoredDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ CourseTutoredDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(CourseTutoredDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
