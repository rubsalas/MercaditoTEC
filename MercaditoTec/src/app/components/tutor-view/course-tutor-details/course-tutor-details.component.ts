import { Component, OnInit } from '@angular/core';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { AuthService } from 'src/app/services/auth.service';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-course-tutor-details',
  templateUrl: './course-tutor-details.component.html',
  styleUrls: ['./course-tutor-details.component.scss']
})
export class CourseTutorDetailsComponent implements OnInit {

  notFound = false;
  public course: CourseTutorInterface = {
    idCursoTutor: 0,
    idTutor: 0,
    idEstudiante: 0,
    nombre: '',
    apellidos: '',
    calificacionPromedioTutor: 0,
    idCurso: 0,
    nombreCurso: '',
    codigo: '',
    carrera: '',
    notaObtenida: 0,
    temas: ''
  };

  constructor(public tutorService: TutorService, public authService: AuthService) { }

  ngOnInit(): void {
    var id = this.authService.getIdCursoTutor();
    this.getCourse(id);
  }

  getCourse(tutorId: string | null) {
      this.notFound = false;

      if(tutorId != null){
        this.tutorService.getTutorCourse(tutorId)
        .subscribe((response : any) => {
          console.log(response)
          this.course = response;
        });
    }
  }
}
