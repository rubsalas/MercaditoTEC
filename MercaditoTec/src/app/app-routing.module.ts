import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminViewComponent } from './components/admin-view/admin-view.component';
import { EmployerViewComponent } from './components/employer-view/employer-view.component';
import { LibraryViewComponent } from './components/library-view/library-view.component';
import { LoginViewComponent } from './components/user/login-view/login-view.component';
import { ProfileViewComponent } from './components/user/profile-view/profile-view.component';
import { RegisterViewComponent } from './components/user/register-view/register-view.component';
import { HomepageComponent } from './components/shared-comp/homepage/homepage.component';
import { VerifyRegisterComponent } from './components/user/verify-register/verify-register.component';
import { GuideViewComponent } from './components/guide-view/guide-view.component';
import { TutorViewComponent } from './components/tutor-view/tutor-view.component';
import { AddCourseTutorComponent } from './components/tutor-view/add-course-tutor/add-course-tutor.component';
import { ProfileAdminComponent } from './components/admin-view/profile-admin/profile-admin.component';
import { MessageCenterComponent } from './components/message-center/message-center.component';
import { AuthGuard } from './guards/auth.guard';

const routes: Routes = [
  {path: '', component:LoginViewComponent},
  {path: 'homepage', component:HomepageComponent},
  {path: 'registerview', component:RegisterViewComponent},
  {path: 'verifyRegister', component:VerifyRegisterComponent},
  {path: 'guideview', component:GuideViewComponent},
  {path: 'profileview', component:ProfileViewComponent},
  {path: 'adminview', component:AdminViewComponent},
  {path: 'employeview', component:EmployerViewComponent},
  {path: 'libraryview', component:LibraryViewComponent},
  {path: 'tutorview', component:TutorViewComponent, canActivate: [AuthGuard]},
  {path: 'addcoursetutor', component:AddCourseTutorComponent},
  {path: 'adminProfile', component:ProfileAdminComponent},
  {path: 'messagecenter', component:MessageCenterComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
