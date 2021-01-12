import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

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
    LibraryViewComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    CommonModule,
    FormsModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
