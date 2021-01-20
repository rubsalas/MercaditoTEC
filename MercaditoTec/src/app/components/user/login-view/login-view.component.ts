import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { LoginInterface } from 'src/app/models/login-interface';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  constructor(public loginService: LoginService) { }

  public login: LoginInterface = {
    correoInstitucional: '',
    contrasena: ''
  };

  public isError = false;

  ngOnInit(): void { }

  //Falta abrir el json y leer el campo 'value'
  onLogin(form: NgForm) {
    if (form.valid) {
      console.log(
        'Informacion a enviar \n  Correo Institucional: '
        +this.login.correoInstitucional
        +' , Contraseña: '
        +this.login.contrasena);

      return this.loginService.postLogin(this.login);
    }
  }

}
