import { ComponentFixture, TestBed } from '@angular/core/testing';

import { EvaluationsTutorViewComponent } from './evaluations-tutor-view.component';

describe('EvaluationsTutorViewComponent', () => {
  let component: EvaluationsTutorViewComponent;
  let fixture: ComponentFixture<EvaluationsTutorViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ EvaluationsTutorViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(EvaluationsTutorViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

});
