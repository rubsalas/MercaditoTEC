import { Component, OnInit } from '@angular/core';
import { TutorService } from 'src/app/services/tutor.service';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { PracticeTutorInterface } from 'src/app/models/practice-tutor-interface';

@Component({
  selector: 'app-practices-tutor-list',
  templateUrl: './practices-tutor-list.component.html',
  styleUrls: ['./practices-tutor-list.component.scss']
})
export class PracticesTutorListComponent implements OnInit {

  public practicesList!: PracticeTutorInterface[];
  public courseName = '';

  constructor(public tutorService: TutorService, 
    public authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    this.getListPractices();
  }

  getListPractices(): void {
    this.tutorService
      .getAllTutorPractices(this.authService.getIdCursoTutor())
      .subscribe( (practices: any) => {
        (this.practicesList = practices)
        console.log(this.practicesList);
      });
  }

  openPractice(practice: PracticeTutorInterface){
    console.log(practice);
    this.authService.grabarPracticeTutor(practice.idPracticaTutor.toString(), practice.nombre);
    this.router.navigateByUrl('/practiceTutorDetails');
  }

}

/*
<h1 class=" mb-3 font-weight-normal text-center" >Información de las practicas del curso</h1>

<div class="container">
  <div class="row row-cols-2">
      <div class="col-xs-12 col-sm-8 mx-auto">
          <div class="card_course">
              <div class="card">
                <div class="card-body ">
                  <ng-container *ngIf="course">
                      <div class="h4 mb-3 font-weight-normal text-center">  Nombre del curso: {{ course.nombreCurso }}                 </div>
                      <div class="h4 mb-3 font-weight-normal text-center">  Código del curso: {{ course.codigo }}           </div>
                      <div class="h4 mb-3 font-weight-normal text-center">  Carrera Asociada: {{ course.carrera }}             </div>
                      <div class="h4 mb-3 font-weight-normal text-center">  Nota Obtenida: {{ course.notaObtenida }}  </div>
                      <div class="h4 mb-3 font-weight-normal text-center">  Temas Relacionados: {{ course.temas }}           </div>
                  </ng-container>
                  <br>
                  <button routerLink="/tutorview"
                  class="btn btn-lg container-fluid btn-success text-center" >
                  Regresar
                  </button>
              </div>
            </div>
          </div>
      </div>
      <div class="col-xs-12 col-sm-4 col-md-4 mx-auto">
          <div class="card_menu">
              <div class="card">
                  <div class="card-body ">
                      <h1 class="h3 mb-3 font-weight-normal text-center" >Menu</h1>
                      <button routerLink="/practiceTutorList"
                      class="btn btn-lg btn-success btn-block text-center" >
                      Ver Prácticas 
                      </button>
                      <button routerLink="/editprofile"
                      class="btn btn-lg btn-success btn-block text-center" >
                      Agregar Práctica
                      </button>
                      <button routerLink="/homepage"
                      class="btn btn-lg btn-success btn-block text-center" >
                      Eliminar Curso
                      </button>
                  </div>
              </div>
          </div>
      </div>
  </div>
</div>

*/