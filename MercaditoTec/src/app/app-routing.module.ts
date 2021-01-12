import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminViewComponent } from './components/admin-view/admin-view.component';
import { EmployerViewComponent } from './components/employer-view/employer-view.component';
import { LibraryViewComponent } from './components/library-view/library-view.component';
import { LoginViewComponent } from './components/user/login-view/login-view.component';
import { ProfileViewComponent } from './components/user/profile-view/profile-view.component';
import { RegisterViewComponent } from './components/user/register-view/register-view.component';
import { HomepageComponent } from './components/shared-comp/homepage/homepage.component';

const routes: Routes = [
  {path: '', component:LoginViewComponent},
  {path: 'homepage', component:HomepageComponent},
  {path: 'registerview', component:RegisterViewComponent},
  {path: 'profileview', component:ProfileViewComponent},
  {path: 'adminview', component:AdminViewComponent},
  {path: 'employerview', component:EmployerViewComponent},
  {path: 'libraryview', component:LibraryViewComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
