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

  public userLogged = '';
  public app_name = 'Mercadito TEC';

  constructor(private authService: AuthService, private location: Location) { 
    /*authService.currentUser.subscribe((nextValue) => {
      this.userLogged=nextValue;
    })*/
  }

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
    var myCurrentUser = this.authService.getCurrentUser();
    console.log(myCurrentUser);

    if (myCurrentUser == 'null') {
      this.adminLogged = false;
      this.libraryLogged = false;
      this.employeeLogged = false;
      this.studentLogged = false;
    } 
    if (myCurrentUser == 'student') {
      this.studentLogged = true;
      this.logout = false;
    }
    if (myCurrentUser == 'admin') {
      this.adminLogged = true;
      this.logout = false;
    }
    if (myCurrentUser == 'employee') {
      this.employeeLogged = true;
      this.logout = false;
    }
    if (myCurrentUser == 'library') {
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
<nav class="navbar navbar-expand-md align-items-center bg-dark fg">
  <a class="navbar-brand hhhh" routerLink="/">{{app_name}}</a>

  <div class="collapse navbar-collapse" id="mainNavbar">
    <ul class="navbar-nav mr-auto">
      <li class="nav-item" *ngIf="adminLogged">
        <a class="nav-link menus" routerLink="/adminProfile"> Perfil </a>
      </li>
    </ul>

    <ul class="navbar-nav ml-auto">
      <li class="nav-item" *ngIf="studentLogged">
        <a class="nav-link menus" routerLink="/profileview"> Perfil</a>
      </li>
      <li class="nav-item" *ngIf="studentLogged">
        <a class="nav-link menus" routerLink="/messagecenter"> Mensajes</a>
      </li>
    </ul>
    
    <ul class="navbar-nav mr-auto">
      <li class="nav-item" *ngIf="logout">
        <a class="nav-link menus" routerLink="/adminview"> Administrador </a>
      </li>
      <li class="nav-item" *ngIf="logout">
        <a class="nav-link menus" routerLink="/employeview"> Empleador </a>
      </li>
      <li class="nav-item" *ngIf="logout">
        <a class="nav-link menus" routerLink="/libraryview"> Sistema Librería </a>
      </li>
      <li class="nav-item" *ngIf="logout">
        <a class="btn btn-success" routerLink="/"> Login </a>
      </li>
      <li class="nav-item" *ngIf="logout">
        <a class="btn btn-success" routerLink="/verifyRegister"> Register </a>
      </li>
      <li class="nav-item" *ngIf="!logout">
        <a routerLink="/" class="btn btn-success" (click)="onLogout()">Salir </a>
      </li>
    </ul>
  </div>
</nav>
*/