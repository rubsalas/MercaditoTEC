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
import { MessageCenterComponent } from './components/message-center/message-center.component';
import { AuthGuard } from './guards/auth.guard';
import { CourseTutorDetailsComponent } from './components/tutor-view/course-tutor-details/course-tutor-details.component';
import { EvaluationsTutorViewComponent } from './components/tutor-view/evaluations-tutor-view/evaluations-tutor-view.component';
import { HomepageAdminComponent } from './components/admin-view/homepage-admin/homepage-admin.component';
import { EditProfileComponent } from './components/user/profile-view/edit-profile/edit-profile.component';
import { NotFoundComponent } from './components/shared-comp/not-found/not-found.component';
import { PracticesTutorListComponent } from './components/tutor-view/practices-tutor-list/practices-tutor-list.component';
import { PracticesTutorDetailsComponent } from './components/tutor-view/practices-tutor-details/practices-tutor-details.component';
import { AddTutorPracticesComponent } from './components/tutor-view/add-tutor-practices/add-tutor-practices.component';

const routes: Routes = [
  {path: '', component:LoginViewComponent},
  {path: 'notfoundpage', component:NotFoundComponent},
  {path: 'verifyRegister', component:VerifyRegisterComponent},
  {path: 'registerview', component:RegisterViewComponent},
  {path: 'guideview', component:GuideViewComponent},
  {path: 'homepage', component:HomepageComponent},
  {path: 'profileview', component:ProfileViewComponent},
  {path: 'editprofile', component:EditProfileComponent},
  {path: 'messagecenter', component:MessageCenterComponent},
  {path: 'tutorview', component:TutorViewComponent, canActivate: [AuthGuard]},
  {path: 'courseTutorDetails', component:CourseTutorDetailsComponent},
  {path: 'addPracticeTutor', component:AddTutorPracticesComponent},
  {path: 'practiceTutorList', component:PracticesTutorListComponent},
  {path: 'practiceTutorDetails', component:PracticesTutorDetailsComponent},
  {path: 'addcoursetutor', component:AddCourseTutorComponent},
  {path: 'evaluationsTutor', component:EvaluationsTutorViewComponent},
  {path: 'adminview', component:AdminViewComponent},
  {path: 'homepageAdmin', component:HomepageAdminComponent},
  {path: 'employeview', component:EmployerViewComponent},
  {path: 'libraryview', component:LibraryViewComponent},
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
