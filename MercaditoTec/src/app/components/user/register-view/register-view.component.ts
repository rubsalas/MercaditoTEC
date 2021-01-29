import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { RegisterInterface } from 'src/app/models/register-interface';
import { LoginService } from 'src/app/services/login.service';

@Component({
  selector: 'app-register-view',
  templateUrl: './register-view.component.html',
  styleUrls: ['./register-view.component.scss']
})
export class RegisterViewComponent implements OnInit {

  constructor(public registerService: LoginService, private router: Router) { }

  public register: RegisterInterface = {
    nombre: '',
    apellidos: '',
    telefono: '',
    correoInstitucional: ''
  };

  public isError = false;

  ngOnInit(): void { }

  //Falta abrir el json y leer el campo 'value'
  //Falta validar las entradas del ngform
  
  onRegister(form: NgForm) {
    if (form.valid) {
      console.log(this.register);

      this.registerService.postRegister(this.register)
      .subscribe( (newRegister: any)  => {
        console.log(newRegister)
        if(newRegister.value == 0){
          console.log("No se pudo registrar");
        }
        if(newRegister.value < 0){
          console.log("Estudiante ya estaa registrado");
        }
        this.router.navigateByUrl('/');
      });
    }
  }

}
