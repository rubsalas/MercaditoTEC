import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticesTutoredDetailsComponent } from './practices-tutored-details.component';

describe('PracticesTutoredDetailsComponent', () => {
  let component: PracticesTutoredDetailsComponent;
  let fixture: ComponentFixture<PracticesTutoredDetailsComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticesTutoredDetailsComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticesTutoredDetailsComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
