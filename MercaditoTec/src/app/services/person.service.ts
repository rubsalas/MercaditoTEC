import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Person } from '../models/person';

@Injectable({
  providedIn: 'root'
})
export class PersonService {

  baseURL = environment.apiURL + 'personas/';
  constructor(private http: HttpClient) { }
  
  getPerson(personId: string): Observable<Person> {
    const url = this.baseURL + personId;
    return this.http.get<Person>(url);
  }

  getPersons(): Observable<Person[]> {
    return this.http.get<Person[]>(this.baseURL);
  }

  getPersonsWithHeaders(): Observable<any> {
    return this.http.get(this.baseURL, {observe: 'response'});
  }

  getPersonsSendHeaders() {
     // headers HTTP
     let headers = new HttpHeaders();
     headers = headers.append('Authorization', 'bearer token2');
     headers = headers.append('X-Pagination', '3');
 
     // query strings
     let params = new HttpParams();
     params = params.append('X-Pagination', '4');
 
     return this.http.get<Person[]>(this.baseURL, {headers, params});
  }

  createPerson(user: Person): Observable<Person>{
    return this.http.post<Person>(this.baseURL, user);
  }

  updatePerson(user: Person): Observable<Person> {
    const url = this.baseURL + user.idPersona;
    return this.http.put<Person>(url, user);
  }

  /*
  patchPerson(id: number, operations: Operation[]){
    const url = this.baseURL + id;
    return this.http.patch(url, operations);
  }
  */

  deletePerson(id: number): Observable<any> {
    const url = this.baseURL + id;
    return this.http.delete(url);
  }
}
