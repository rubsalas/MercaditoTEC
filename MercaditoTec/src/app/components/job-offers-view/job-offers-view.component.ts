import { Component, OnInit } from '@angular/core';
import { CourseTutoredInterface } from 'src/app/models/course-tutored-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { CarrerInterface } from 'src/app/models/carrer-interface';
import { JobOffersService } from 'src/app/services/job-offers.service';
import { JobOfferInterface } from 'src/app/models/job-offer-interface';

@Component({
  selector: 'app-job-offers-view',
  templateUrl: './job-offers-view.component.html',
  styleUrls: ['./job-offers-view.component.scss']
})
export class JobOffersViewComponent implements OnInit {

  //public carrersList!: CourseTutoredInterface[];
  public carrersLibrary: CarrerInterface[] | undefined;
  public jobOffersList: JobOfferInterface[] | undefined;

  notFound = false;
  public searchCarrer = '';
  public isSearch = false;

  constructor(public jobOffersService: JobOffersService,
    public authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    //this.getListCourses();
    this.loadCarrersLibrary();
  }

  getListCarrers(): void {
    this.jobOffersService
      .getAllSearchCarrers(this.authService.getidCarrerSearch())
      .subscribe( (jobOffers: any) => {
        (this.jobOffersList = jobOffers)
        console.log(this.jobOffersList);
      });
      
  }

  openJobOffer(jobOffer: JobOfferInterface){
    console.log(jobOffer);
    this.authService.grabaridCarrerSelect(jobOffer.idOfertaLaboral.toString());
    this.router.navigateByUrl('/jobofferDetails');
  }

  loadCarrersLibrary(){
    this.jobOffersService.getCarrersLibrary()
    .subscribe( (carrersFromApi: any) => {
      console.log(carrersFromApi)
      this.carrersLibrary = carrersFromApi;
    });
  }

  buscarCarrera(){
    console.log('ID CARRERA: '+ this.searchCarrer)
    this.isSearch = true;
    this.authService.grabaridCarrerSearch(this.searchCarrer);
    this.getListCarrers();

  }

}
