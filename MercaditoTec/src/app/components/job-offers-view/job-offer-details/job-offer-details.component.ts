import { Component, OnInit } from '@angular/core';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { JobOfferInterface } from 'src/app/models/job-offer-interface';
import { AuthService } from 'src/app/services/auth.service';
import { JobOffersService } from 'src/app/services/job-offers.service';
import { TutorService } from 'src/app/services/tutor.service';

@Component({
  selector: 'app-job-offer-details',
  templateUrl: './job-offer-details.component.html',
  styleUrls: ['./job-offer-details.component.scss']
})
export class JobOfferDetailsComponent implements OnInit {

  notFound = false;
  public jobOffer: JobOfferInterface = {
    idOfertaLaboral: 0,
    idEmpleador: 0,
    nombrePuesto: '',
    responsabilidades: '',
    requerimientos: '',
    idCarrera: 0,
    idUbicacion: 0,
    jornadaLaboral: '',
    link: '',
    fechaPublicacion: '',
  };

  constructor(public jobOfferService: JobOffersService, public authService: AuthService) { }

  ngOnInit(): void {
    var id = this.authService.getidCarrerSelect();
    this.getJobOffer(id);
  }

  getJobOffer(idOfertaLaboral: string | null) {
      this.notFound = false;

      if(idOfertaLaboral != null){
        this.jobOfferService.getOfferForCarrer(idOfertaLaboral)
        .subscribe((response : any) => {
          console.log(response)
          this.jobOffer = response;
        });
    }
  }
}
