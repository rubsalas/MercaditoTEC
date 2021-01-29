import { ComponentFixture, TestBed } from '@angular/core/testing';

import { AddTutorPracticesComponent } from './add-tutor-practices.component';

describe('AddTutorPracticesComponent', () => {
  let component: AddTutorPracticesComponent;
  let fixture: ComponentFixture<AddTutorPracticesComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ AddTutorPracticesComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(AddTutorPracticesComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
