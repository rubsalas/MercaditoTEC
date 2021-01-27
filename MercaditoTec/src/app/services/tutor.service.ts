import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class TutorService {

  coursesURL = environment.apiURL + 'cursosTutorJ/Estudiante/';

  constructor(private http: HttpClient) { }

  getAllTutorCourses(idTutor: string) {
    let url=this.coursesURL + idTutor;
    return this.http.get(url);
  }
}
