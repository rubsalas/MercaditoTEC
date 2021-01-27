import { Component, OnInit } from '@angular/core';
import { LoginService } from 'src/app/services/login.service';
import { LoginInterface } from 'src/app/models/login-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { StudentService } from 'src/app/services/student.service';
import { StudentInterface } from 'src/app/models/student-interface';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-view',
  templateUrl: './login-view.component.html',
  styleUrls: ['./login-view.component.scss']
})
export class LoginViewComponent implements OnInit {

  public login: LoginInterface = {
    correoInstitucional: '',
    contrasena: ''
  };

  public student: StudentInterface = {
    idEstudiante: 0,
    nombre: '',
    apellidos: '',
    telefono: '',
    email: '',
    correoInstitucional: '',
    puntosCanje: 0,
    haIngresadoWeb: false,
    haIngresadoApp: false,
    calificacionPromedioTutor: 0,
    cantidadAplicaciones: 0,
    calificacionPromedioProductos: 0,
    calificacionPromedioServicios: 0
  };

  public isError = false;
  public idEstudiante = 'none';

  constructor(public loginService: LoginService, 
    public authService: AuthService,
    public studentService: StudentService,
    private router: Router) { }

  ngOnInit(): void { }

  onLogin(form: NgForm) {
    if (form.valid) {
      console.log('LOGIN A ENVIAR');
      console.log(this.login);     
      
      this.loginService.postLogin(this.login)
      .subscribe( (getLogin: any) => {
        
        console.log(getLogin)
        this.idEstudiante = getLogin.value
        this.authService.grabarId(this.idEstudiante)
        this.authService.loginUser("student");

        this.router.navigate(['/shared-comp/homepage']);
        location.reload();
        this.isError = false;
      },
      error => this.onIsError()
      ); 
    }else {
      this.onIsError();
    }
  }

  onIsError(): void {
    this.isError = true;
    setTimeout(() => {
      this.isError = false;
    }, 4000);
  }

}

/*

routerLink="/homepage"

if(this.authService.showGuide){
          this.studentService.getStudent(this.idEstudiante)
          .subscribe(response => {
            this.student = response
            if(!this.student.haIngresadoWeb){
              this.authService.setGuideOption(false);
            }else{
              this.authService.setGuideOption(false);
            }
          });
        };
        */
