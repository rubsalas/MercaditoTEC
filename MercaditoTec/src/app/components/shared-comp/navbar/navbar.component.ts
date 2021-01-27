import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/services/auth.service';
import { Location } from '@angular/common';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.scss']
})
export class NavbarComponent implements OnInit {
  //routerLink="/general" routerLinkActive="router-link-active"

  constructor(private authService: AuthService, private location: Location) { }
  
  public app_name = 'Mercadito TEC';

  public adminLogged = false;
  public libraryLogged = false;
  public employeeLogged = false;
  public studentLogged = false;

  public logout = true;
  
  ngOnInit(): void { 
    this.onCheckUser();
  }

  onLogout(): void {
    this.adminLogged = false;
    this.libraryLogged = false;
    this.employeeLogged = false;
    this.studentLogged = false;

    this.logout = true;

    this.authService.logoutUser();
    //location.reload();
  }

  onCheckUser(): void {
    if (this.authService.getCurrentUser() == 'null') {
      this.adminLogged = false;
      this.libraryLogged = false;
      this.employeeLogged = false;
      this.studentLogged = false;
    } 
    if (this.authService.getCurrentUser() == 'student') {
      this.studentLogged = true;
      this.logout = false;
    }
    if (this.authService.getCurrentUser() == 'admin') {
      this.adminLogged = true;
      this.logout = false;
    }
    if (this.authService.getCurrentUser() == 'employee') {
      this.employeeLogged = true;
      this.logout = false;
    }
    if (this.authService.getCurrentUser() == 'library') {
      this.libraryLogged = true;
      this.logout = false;
    }
  }

}

/*
<nav class="navbar navbar-dark fixed-top bg-primary">
  <a class="navbar-brand" routerLink="/">{{app_name}}</a>
  <button class="navbar-toggler" type="button" data-toggle="collapse" 
    data-target="#mainNavbar" aria-controls="mainNavbar"
    aria-expanded="false" aria-label="Toggle navigation">
    <span class="navbar-toggler-icon"></span>
  </button>

  <div class="collapse navbar-collapse" id="mainNavbar">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item" *ngIf="adminLogged">
        <a class="nav-link" routerLink="/adminProfile"> Perfil </a>
      </li>
    </ul>
    <ul class="navbar-nav ml-auto">
      <li class="nav-item" *ngIf="studentLogged">
        <a class="nav-link" routerLink="/profileview"> Perfil</a>
      </li>
      <li class="nav-item" *ngIf="studentLogged">
        <a class="nav-link" routerLink="/messagecenter"> Mensajes</a>
      </li>
    </ul>
    <ul class="navbar-nav mr-auto">
      <li class="nav-item" *ngIf="logout">
        <a class="nav-link" routerLink="/"> Login </a>
      </li>
      
      <li class="nav-item" *ngIf="logout">
        <a class="nav-link" routerLink="/registerview"> Register </a>
      </li>
      <li class="nav-item" *ngIf="!logout">
        <a routerLink="/" class="nav-link" (click)="onLogout()">Salir </a>
      </li>
    </ul>
  </div>
</nav>
*/

/*
<div class="nav d-flex flex-column flex-md-row align-items-center p-3 px-md-4 mb-3 shadow-sm">
  <h3 class="my-0 mr-md-auto fg font-weight-strong">
    MercaditoTEC
  </h3>
  <nav class="my-2 my-md-0 mr-md-3 navBar">
    <div class="row"> 
      <div>
        <a class="btn btn-primary menus" routerLink="/adminview"> Perfil Administración </a>
      </div>

      <div>
        <a class="btn btn-primary menus" routerLink="/employerview"> Perfil Empleador </a>
      </div>

      <div>
        <a class="btn btn-primary menus" routerLink="/libraryview"> Sistema Librería </a>
      </div>

      <div>
        <!-- <a class="btn btn-primary btn-register" [routerLink]="'/register'">Sign up</a> -->
        <a class="btn btn-outline-secondary btn-register" routerLink="/verifyRegister"> Registrarse</a>
      </div>
    </div>
  </nav>
</div>
*/