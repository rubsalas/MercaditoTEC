import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Subject } from 'rxjs';
import { Observable } from 'rxjs/internal/Observable';
import { CarrerInterface } from '../models/carrer-interface';
import { JobOfferInterface } from '../models/job-offer-interface';

@Injectable({
  providedIn: 'root'
})
export class JobOffersService {

  carrerLibraryURL = environment.apiURL + 'carreras';
  searchCarrersURL = environment.apiURL + 'ofertasLaboralesJ/Carrera/';
  OfferForCarrerURL = environment.apiURL + 'ofertasLaboralesJ/';

  constructor(private http: HttpClient) { }

  getCarrersLibrary(): Observable<CarrerInterface[]>{
    console.log('SOLICITAR BIBLIOTECA DE CARRERAS: '+ this.carrerLibraryURL)
    return this.http.get<CarrerInterface[]>(this.carrerLibraryURL);
  }

  getAllSearchCarrers(idCarrera: string | null): Observable<JobOfferInterface[]>{
    let url = this.searchCarrersURL + idCarrera;
    console.log('BUSCAR CURSOS DE LA CARRERA: '+ url)
    return this.http.get<JobOfferInterface[]>(url);
  }

  getOfferForCarrer(idOfertaLaboral: string | null): Observable<JobOfferInterface[]>{
    let url = this.OfferForCarrerURL + idOfertaLaboral;
    console.log('SOLICITAR OFERTA LABORAL: ')
    return this.http.get<JobOfferInterface[]>(url);
  }
}
