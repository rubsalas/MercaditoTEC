import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticesTutorListComponent } from './practices-tutor-list.component';

describe('PracticesTutorListComponent', () => {
  let component: PracticesTutorListComponent;
  let fixture: ComponentFixture<PracticesTutorListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticesTutorListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticesTutorListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
