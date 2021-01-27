import { NgModule } from '@angular/core';

import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginViewComponent } from './components/user/login-view/login-view.component';
import { NavbarComponent } from './components/shared-comp/navbar/navbar.component';
import { FooterComponent } from './components/shared-comp/footer/footer.component';
import { HomepageComponent } from './components/shared-comp/homepage/homepage.component';
import { RegisterViewComponent } from './components/user/register-view/register-view.component';
import { ProfileViewComponent } from './components/user/profile-view/profile-view.component';
import { AdminViewComponent } from './components/admin-view/admin-view.component';
import { EmployerViewComponent } from './components/employer-view/employer-view.component';
import { LibraryViewComponent } from './components/library-view/library-view.component';

import { CommonModule } from '@angular/common';
import { FormsModule }   from '@angular/forms';
import { VerifyRegisterComponent } from './components/user/verify-register/verify-register.component';
import { GuideViewComponent } from './components/guide-view/guide-view.component';
import { LoginService } from './services/login.service';
import { AuthService } from './services/auth.service';
import { StudentService } from './services/student.service';
import { TutorViewComponent } from './components/tutor-view/tutor-view.component';
import { AddCourseTutorComponent } from './components/tutor-view/add-course-tutor/add-course-tutor.component';
import { HomepageAdminComponent } from './components/admin-view/homepage-admin/homepage-admin.component';
import { ProfileAdminComponent } from './components/admin-view/profile-admin/profile-admin.component';
import { MessageCenterComponent } from './components/message-center/message-center.component';
import { TruncateTextPipe } from './pipes/truncate-text.pipe';

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
    AddCourseTutorComponent,
    HomepageAdminComponent,
    ProfileAdminComponent,
    MessageCenterComponent,
    TruncateTextPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [LoginService, AuthService, StudentService],
  bootstrap: [AppComponent]
})
export class AppModule { }

