import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { AddCourseInterface } from 'src/app/models/add-course-interface';
import { CourseLibraryInterface } from 'src/app/models/course-library-interface';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { AuthService } from 'src/app/services/auth.service';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-add-course-tutor',
  templateUrl: './add-course-tutor.component.html',
  styleUrls: ['./add-course-tutor.component.scss']
})
export class AddCourseTutorComponent implements OnInit {

  public course: AddCourseInterface = {
    idTutor: 0,
    idCurso: 0,
    notaObtenida: 0,
    temas: ' '
  }

  public saveId = '';

  public coursesLibrary: CourseLibraryInterface[] | undefined;

  constructor(public tutorService: TutorService,  
    public authService: AuthService,
    private router: Router) { }

  ngOnInit(): void {
    this.loadCoursesLibrary();
  }

  addCourse(form: NgForm) {
    if (form.valid) {
      var myidtutor = this.authService.getIdStudent();
      
      if(myidtutor != null){
        this.course.idTutor = parseInt(myidtutor);
        this.course.idCurso = parseInt(this.saveId);
        console.log(this.course);

        this.tutorService.addTutorCourse(this.course)
        .subscribe( (response: any) => {
          console.log(response)
          this.router.navigateByUrl('/tutorview');;
        });
      }
    }
  }

  loadCoursesLibrary(){
    this.tutorService.getCoursesLibrary()
    .subscribe( (coursesFromApi: any) => {
      console.log(coursesFromApi)
      this.coursesLibrary = coursesFromApi;
    });
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