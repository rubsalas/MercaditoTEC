import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-add-course-tutor',
  templateUrl: './add-course-tutor.component.html',
  styleUrls: ['./add-course-tutor.component.scss']
})
export class AddCourseTutorComponent implements OnInit {

  constructor(public tutorService: TutorService) { }

  public course: CourseTutorInterface | undefined;

  ngOnInit(): void {
  }

  addCourse(form: NgForm) {
    if (form.valid) {
      console.log(this.course);

      //this.tutorService
    }
  }

}

/*
<div class="form-group">
                    <label >Nombre</label>
                    <input type="text" id="nombre" name="nombre" class="form-control text-center" [(ngModel)]="register.nombre" required>
                  </div>
                  <div class="form-group">
                    <label>Apellidos</label>
                    <input type="text" id="apellidos" name="apellidos" class="form-control text-center" [(ngModel)]="register.apellidos" required>
                  </div>
                  <div class="form-group">
                    <label >Teléfono</label>
                    <input type="text" id="telefono" name="telefono" class="form-control text-center" [(ngModel)]="register.telefono" required>
                  </div>
                  <div class="form-group">
                    <label>Correo Institucional</label>
                    <input type="email" id="correoInstitucional" name="correoInstitucional" class="form-control text-center" placeholder="user@estudiantec.cr" [(ngModel)]="register.correoInstitucional" required>
                  </div>
*/

/*
.postRegister(this.register)
      .subscribe( (newRegister: any)  => {
        console.log(newRegister);
        if(newRegister.value == 0){
          console.log("No se pudo registrar");
        }
        if(newRegister.value < 0){
          console.log("Estudiante ya estaa registrado");
        };
      });
    }

    */