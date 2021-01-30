import { NgModule } from '@angular/core';

/* --------------------    IMPORTAR MODULOS   ------------------------*/
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';

/* --------------------    IMPORTAR COMPONENTES   ------------------------*/
import { AppComponent } from './app.component';
import { NavbarComponent } from './components/shared-comp/navbar/navbar.component';
import { FooterComponent } from './components/shared-comp/footer/footer.component';
import { HomepageComponent } from './components/shared-comp/homepage/homepage.component';
import { MessageCenterComponent } from './components/message-center/message-center.component';

import { LoginViewComponent } from './components/user/login-view/login-view.component';
import { RegisterViewComponent } from './components/user/register-view/register-view.component';
import { VerifyRegisterComponent } from './components/user/verify-register/verify-register.component';
import { GuideViewComponent } from './components/guide-view/guide-view.component';
import { NotFoundComponent } from './components/shared-comp/not-found/not-found.component';

import { ProfileViewComponent } from './components/user/profile-view/profile-view.component';
import { EditProfileComponent } from './components/user/profile-view/edit-profile/edit-profile.component';

import { AdminViewComponent } from './components/admin-view/admin-view.component';
import { HomepageAdminComponent } from './components/admin-view/homepage-admin/homepage-admin.component';

import { EmployerViewComponent } from './components/employer-view/employer-view.component';
import { LibraryViewComponent } from './components/library-view/library-view.component';

import { TutorViewComponent } from './components/tutor-view/tutor-view.component';
import { AddCourseTutorComponent } from './components/tutor-view/add-course-tutor/add-course-tutor.component';
import { EvaluationsTutorViewComponent } from './components/tutor-view/evaluations-tutor-view/evaluations-tutor-view.component';
import { CourseTutorDetailsComponent } from './components/tutor-view/course-tutor-details/course-tutor-details.component';
import { PracticesTutorListComponent } from './components/tutor-view/practices-tutor-list/practices-tutor-list.component';
import { PracticesTutorDetailsComponent } from './components/tutor-view/practices-tutor-details/practices-tutor-details.component';
import { AddTutorPracticesComponent } from './components/tutor-view/add-tutor-practices/add-tutor-practices.component';

/* --------------------    IMPORTAR SERVICIOS   ------------------------*/
import { LoginService } from './services/login.service';
import { AuthService } from './services/auth.service';
import { StudentService } from './services/student.service';
import { TutorService } from './services/tutor.service';
import { TutoredViewComponent } from './components/tutored-view/tutored-view.component';
import { CourseTutoredDetailsComponent } from './components/tutored-view/course-tutored-details/course-tutored-details.component';
import { PracticesTutoredDetailsComponent } from './components/tutored-view/practices-tutored-details/practices-tutored-details.component';
import { PracticesTutoredListComponent } from './components/tutored-view/practices-tutored-list/practices-tutored-list.component';
import { JobOffersViewComponent } from './components/job-offers-view/job-offers-view.component';
import { SearchResultsComponent } from './components/tutored-view/search-results/search-results.component';
import { SearchCourseDetailsComponent } from './components/tutored-view/search-course-details/search-course-details.component';
import { JobOfferDetailsComponent } from './components/job-offers-view/job-offer-details/job-offer-details.component';


@NgModule({
  declarations: [
    AppComponent,
    LoginViewComponent,
    NavbarComponent,
    FooterComponent,
    HomepageComponent,
    RegisterViewComponent,
    ProfileViewComponent,
    AdminViewComponent,
    EmployerViewComponent,
    LibraryViewComponent,
    VerifyRegisterComponent,
    GuideViewComponent,
    TutorViewComponent,
    EvaluationsTutorViewComponent,
    CourseTutorDetailsComponent,
    AddCourseTutorComponent,
    HomepageAdminComponent,
    MessageCenterComponent,
    EditProfileComponent,
    NotFoundComponent,
    PracticesTutorListComponent,
    PracticesTutorDetailsComponent,
    AddTutorPracticesComponent,
    TutoredViewComponent,
    CourseTutoredDetailsComponent,
    PracticesTutoredDetailsComponent,
    PracticesTutoredListComponent,
    JobOffersViewComponent,
    SearchResultsComponent,
    SearchCourseDetailsComponent,
    JobOfferDetailsComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [LoginService, AuthService, StudentService, TutorService],
  bootstrap: [AppComponent]
})
export class AppModule { }

