import { Component, OnInit } from '@angular/core';
import { CourseTutoredInterface } from 'src/app/models/course-tutored-interface';
import { AuthService } from 'src/app/services/auth.service';
import { TutoredService } from 'src/app/services/tutored.service';

@Component({
  selector: 'app-course-tutored-details',
  templateUrl: './course-tutored-details.component.html',
  styleUrls: ['./course-tutored-details.component.scss']
})
export class CourseTutoredDetailsComponent implements OnInit {

  notFound = false;
  public course: CourseTutoredInterface = {
    idCursoTutorado: 0,
    idTutorado: 0,
    nombreTutorado: '',
    idCursoTutor: 0,
    idTutor: 0,
    nombreTutor: '',
    calificacionPromedioTutor: 0,
    idCurso: 0,
    nombreCurso: '',
    codigo: '',
    notaObtenida: 0,
    temas: '',
    
  };

  public isSaved = false;

  constructor(public tutorService: TutoredService, public authService: AuthService) { }

  ngOnInit(): void {
    var id = this.authService.getIdCursoTutored();
    
    this.getCourse(id);
  }

  getCourse(tutorId: string | null) {
      this.notFound = false;

      if(tutorId != null){
        this.tutorService.getTutoredCourse(tutorId)
        .subscribe((response : any) => {
          console.log(response)
          this.course = response;
        });
    }
  }

  savedCourse(course: CourseTutoredInterface){
    this.isSaved = true;
  }

  leavedCourse(course: CourseTutoredInterface){
    this.isSaved = false;
  }

}