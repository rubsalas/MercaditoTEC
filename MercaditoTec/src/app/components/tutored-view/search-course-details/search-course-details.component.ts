import { Component, OnInit } from '@angular/core';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { CourseTutoredInterface } from 'src/app/models/course-tutored-interface';
import { AuthService } from 'src/app/services/auth.service';
import { TutorService } from 'src/app/services/tutor.service';
import { TutoredService } from 'src/app/services/tutored.service';

@Component({
  selector: 'app-search-course-details',
  templateUrl: './search-course-details.component.html',
  styleUrls: ['./search-course-details.component.scss']
})
export class SearchCourseDetailsComponent implements OnInit {

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

  public isSaved = false;

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

  savedCourse(course: CourseTutorInterface){
    this.isSaved = true;
    console.log(course);
  }

  leavedCourse(course: CourseTutorInterface){
    this.isSaved = false;
    console.log(course);
  }

}