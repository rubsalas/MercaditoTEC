import { Component, OnInit } from '@angular/core';
import { TutorService } from 'src/app/services/tutor.service';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { StudentService } from 'src/app/services/student.service';
import { StudentInterface } from 'src/app/models/student-interface';

@Component({
  selector: 'app-tutor-view',
  templateUrl: './tutor-view.component.html',
  styleUrls: ['./tutor-view.component.scss']
})
export class TutorViewComponent implements OnInit {

  public coursesList!: CourseTutorInterface[];
  notFound = false;

  public student: StudentInterface = {
    idEstudiante: 0,
    nombre: '',
    apellidos: '',
    telefono: '',
    correoInstitucional: '',
    puntosCanje: 0,
    calificacionPromedioTutor: 0,
    cantidadAplicaciones: 0,
    calificacionPromedioProductos: 0,
    calificacionPromedioServicios: 0
  };

  constructor(public tutorService: TutorService,
    public studentService: StudentService,
    public authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    this.getListCourses();
    var id = this.authService.getIdStudent();
    this.getStudent(id);
  }

  getListCourses(): void {
    this.tutorService
      .getAllTutorCourses(this.authService.getIdStudent())
      .subscribe( (courses: any) => {
        (this.coursesList = courses)
        console.log(this.coursesList);
      });
  }

  getStudent(studentId: string | null) {
    this.notFound = false;

    this.studentService.getProfileStudent(studentId)
    .subscribe((studentFromTheAPI : any) => {
      this.student = studentFromTheAPI;
    });
  }

  openCourse(course: CourseTutorInterface){
    console.log(course);
    this.authService.grabarCursoTutor(course.idCursoTutor.toString(),course.nombreCurso);
    this.router.navigateByUrl('/courseTutorDetails');
  }

}

/*
<ng-container *ngIf="student">
                          <div class="h4 mb-3 font-weight-normal text-center">  Nombre: {{ student.nombre }}                 </div>
                        </ng-container>
*/

/*
<div class="row mt-5">
  <div class="col">
    <table class="table table-hover">
      <thead>
        <tr>
          <th scope="col">No.</th>
          <th scope="col">Nombre del Curso</th>
          <th scope="col">Código del Curs0</th>
          <th scope="col">&nbsp;</th>
        </tr>
      </thead>
      <tbody>
        <tr *ngFor="let course of courses | paginate: {itemsPerPage: 50, currentPage: pageActual}; index as i">
          <th scope="row"> {{i+1}}</th>
          <td>{{course.nombre}}</td>
          <td>{{course.nombreCurso}}</td>
          <td>
            <button class="btn btn-primary" (click)="openCourse(course)" data-toggle="modal" data-target="#modalBook">Ver Curso</button>
          </td>
        </tr>
      </tbody>
    </table>
    <pagination-controls (pageChange)="pageActual = $event"></pagination-controls>
  </div>
</div>
*/

/*
<section id="tutorview" class="mb-5 mt-5">
    <div class="container">
      <div class="row">
        <div class="col-xs-12 col-sm-6 col-md-4 mx-auto">
          <div class="card_tutorview">
            <div class="card">
              <div class="card-body ">
  
                <h1 class="h3 mb-3 font-weight-normal text-center" >Mi perfil como tutor</h1>
                
                <button routerLink="/homepage"
                class="btn btn-lg btn-success btn-block text-center" >
                Ver cursos
                </button>
  
                <button routerLink="/addcoursetutor"
                class="btn btn-lg btn-success btn-block text-center" >
                Agregar Curso
                </button>
  
                <button routerLink="/homepage"
                class="btn btn-lg btn-success btn-block text-center" >
                Ver Evaluaciones
                </button>
  
             </div>
            </div>
          </div>
        </div>
      </div>
    </div>
  </section>
*/