import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { RegisterInterface } from 'src/app/models/register-interface';
import { RegisterService } from 'src/app/services/register.service';

@Component({
  selector: 'app-register-view',
  templateUrl: './register-view.component.html',
  styleUrls: ['./register-view.component.scss']
})
export class RegisterViewComponent implements OnInit {

  constructor(public registerService: RegisterService) { }

  public register: RegisterInterface = {
    nombre: '',
    apellidos: '',
    telefono: '',
    correoInstitucional: ''
  };

  public isError = false;

  ngOnInit(): void { }

  //Falta abrir el json y leer el campo 'value'
  onRegister(form: NgForm) {
    if (form.valid) {
      console.log(
        'Informacion a enviar \n  Nombre: '
        +this.register.nombre
        +' , Apellidos: '
        +this.register.apellidos
        +' , Telefono: '
        +this.register.telefono
        +' , Correo Institucional: '
        +this.register.correoInstitucional);

      return this.registerService.postRegister(this.register);
    }
  }


}
