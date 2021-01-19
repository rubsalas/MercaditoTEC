import { Component, OnInit } from '@angular/core';
import { DaticService } from 'src/app/services/datic.service';
import { DaticInterface } from 'src/app/modelos/datic-interface';
import { NgForm } from '@angular/forms';

@Component({
  selector: 'app-verify-register',
  templateUrl: './verify-register.component.html',
  styleUrls: ['./verify-register.component.scss']
})
export class VerifyRegisterComponent implements OnInit {

  constructor(public daticService: DaticService) { }

  public datic: DaticInterface = {
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
        +this.datic.correoInstitucional
        +' , Contraseña: '
        +this.datic.contrasena)

      return this.daticService.postDatic(this.datic);
    }
  }

}



/*

postDatic() {
    const datic = {
      correoInstitucional: "verrier@estudiantec.cr",
      contrasena: "WhV18mbd03bm"
    };

    this.daticService.postDatic(datic);
  }

// metodo para generar el formulario del put
  generateForm(daticForm?: NgForm) {
    if (daticForm != null) {
      daticForm.reset();
    }
    this.datic = {
        correoInstitucional: '',
        contrasena: ''
    };
  }

  // metodo para hacer el post
  onSubmit(pacienteForm: NgForm) {
    console.log(this.datic);
    console.log(this.daticService.postPaciente(this.datic));
    this.generateForm();
    //window.location.reload();
  }
*/
/*

verifyDatic(Email: string, Password: string): void {
    if (!Email) { return; }
    if (!Password) { return; }

    this.datic.correoInstitucional = Email;
    this.datic.contrasena = Password;

    this.daticService.createPerson(this.datic)
    .subscribe( res => { 
      console.log (res); 
    });
  }

datic : Datic;
  declare var $: any;

  datic = new Datic();

  constructor(private daticService: DaticService) { }

  ngOnInit() { 
    
    /*var daticService = this.daticService;

    $(document).ready(function () {
      $("#verificarDatic").click(function () {
        var correoInst = $("#correoInstitucional").val();
        var contrasena = $("#contrasena").val();

        console.log("Correo: "+ correoInst + " Password: "+ contrasena);

        daticService.createStudent(correoInst, contrasena);
      });
    })
  }
 
  addDatic() {
    this.daticService.addPerson(this.person)
      .subscribe(data => {
        console.log(data)
        this.refreshPeople();
      })      
  }

  */