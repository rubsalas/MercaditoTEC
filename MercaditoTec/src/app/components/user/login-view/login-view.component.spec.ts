import { HttpClientModule } from '@angular/common/http';
import { waitForAsync, ComponentFixture, TestBed } from '@angular/core/testing';
import { RouterTestingModule } from '@angular/router/testing';
import { ActivatedRoute, convertToParamMap, Router } from '@angular/router';
import { LoginViewComponent } from './login-view.component';
import { of } from 'rxjs';

const ActivatedRouteSpy = {
  snapshot: {
    paramMap: convertToParamMap({
      some: 'some',
      else: 'else',
    })
  },
  queryParamMap: of(
    convertToParamMap({
      some: 'some',
      else: 'else',
    })
  )
};

const RouterSpy = jasmine.createSpyObj(
  'Router',
  ['navigate']
);

describe('LoginViewComponent', () => {
  let component: LoginViewComponent;
  let fixture: ComponentFixture<LoginViewComponent>;

  beforeEach(waitForAsync(() => {
    TestBed.configureTestingModule({
      imports: [
        HttpClientModule,
        RouterTestingModule,
      ],
      declarations: [ LoginViewComponent ],
      providers: [
        { provide: ActivatedRoute,   useValue: ActivatedRouteSpy    },
        { provide: Router,           useValue: RouterSpy            }
      ]
    })
    .compileComponents();
  }));

  beforeEach(waitForAsync(() => {
    fixture = TestBed.createComponent(LoginViewComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  }));

});




