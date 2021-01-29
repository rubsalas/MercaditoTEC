import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { AdminInterface } from 'src/app/models/admin-interface';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.scss']
})
export class AdminViewComponent implements OnInit {

  public login: AdminInterface = {
    usuario: '',
    contrasena: ''
  };

  constructor(public loginService: LoginService, 
    public authService: AuthService,
    private router: Router) { }

  ngOnInit(): void { }

  onLogin(form: NgForm) {
    if (form.valid) {
      console.log('LOGIN ADMIN A ENVIAR');
      console.log(this.login);     
      
      this.loginService.postLoginAdmin(this.login)
      .subscribe( (getLogin: any) => {
        console.log(getLogin)
        this.router.navigateByUrl('/homepageAdmin');
      });
    }
  }

}

/*

import { Person } from 'src/app/models/person';
import { PersonService } from 'src/app/services/person.service';

Put the person ID:
<input type="text" #textId>
<button (click)="getPerson(textId.value)">Get person</button>

<hr>

<ng-container *ngIf="notFound">
  User not found
</ng-container>

<ng-container *ngIf="person">
  <div>
    Id: {{ person.idPersona }}
  </div>

  <div>
    Nombre: {{ person.nombre }}
  </div>

  <div>
    Apellidos: {{ person.apellidos }}
  </div>

  <div>
    Telefono: {{ person.telefono }}
  </div>
</ng-container>

notFound = false;
  person: Person | undefined;
getPerson(personId: string) {
    this.notFound = false;
    //this.person = null;

    this.personService.getPerson(personId).subscribe((personFromTheAPI : Person) => {
      this.person = personFromTheAPI;
    }, (err: any) => {
      console.error(err);
      this.notFound = true;
    });
  }
*/
