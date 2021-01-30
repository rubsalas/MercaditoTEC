import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticesTutorDetailsComponent } from './practices-tutor-details.component';

describe('PracticesTutorDetailsComponent', () => {
  let component: PracticesTutorDetailsComponent;
  let fixture: ComponentFixture<PracticesTutorDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticesTutorDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticesTutorDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

});
