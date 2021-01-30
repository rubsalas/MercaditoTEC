import { Component, OnInit } from '@angular/core';
import { PracticeTutorInterface } from 'src/app/models/practice-tutor-interface';
import { AuthService } from 'src/app/services/auth.service';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-practices-tutor-details',
  templateUrl: './practices-tutor-details.component.html',
  styleUrls: ['./practices-tutor-details.component.scss']
})
export class PracticesTutorDetailsComponent implements OnInit {

  notFound = false;
  public practice: PracticeTutorInterface = {
    idPracticaTutor: 0,
    nombre: '',
    descripcion: '',
    cantidadEjercicios: 0,
    precio: 0,
    pdfPractica: '',
    pdfSolucion: '',
    temas: '',
    metodosPago: '',
  };

  constructor(public tutorService: TutorService, public authService: AuthService) { }

  ngOnInit(): void {
    var idpracticatutor = this.authService.getIdCursoTutor();
    this.getPractice(idpracticatutor);
  }

  getPractice(idPractica: string | null) {
      this.notFound = false;

      if(idPractica != null){
        this.tutorService.getTutorPractice(idPractica)
        .subscribe((response : any) => {
          console.log(response)
          this.practice = response;
        });
    }
  }

}


