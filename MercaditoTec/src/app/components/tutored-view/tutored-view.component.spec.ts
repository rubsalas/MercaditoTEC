import { ComponentFixture, TestBed } from '@angular/core/testing';

import { TutoredViewComponent } from './tutored-view.component';

describe('TutoredViewComponent', () => {
  let component: TutoredViewComponent;
  let fixture: ComponentFixture<TutoredViewComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ TutoredViewComponent ]
    })
    .compileComponents();
  });

  beforeEach(() => {
    fixture = TestBed.createComponent(TutoredViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
