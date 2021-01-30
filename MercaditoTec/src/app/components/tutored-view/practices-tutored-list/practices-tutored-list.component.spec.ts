import { ComponentFixture, TestBed } from '@angular/core/testing';

import { PracticesTutoredListComponent } from './practices-tutored-list.component';

describe('PracticesTutoredListComponent', () => {
  let component: PracticesTutoredListComponent;
  let fixture: ComponentFixture<PracticesTutoredListComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ PracticesTutoredListComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(PracticesTutoredListComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
