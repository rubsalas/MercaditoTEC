import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentInterface } from '../models/student-interface';
import { EditProfileInterface } from '../models/edit-profile-interface';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  profileStudentURL = environment.apiURL + 'estudiantesJ/Perfil/';
  studentURL = environment.apiURL + 'estudiantesJ/';
  constructor(private http: HttpClient) { }

  getProfileStudent(studentId: string | null): Observable<StudentInterface> {
    const url = this.profileStudentURL + studentId;
    console.log('GET ESTUDENT: '+url);
    return this.http.get<StudentInterface>(url);
  }

  updateProfileStudent(user: EditProfileInterface): Observable<EditProfileInterface> {
    const url = this.studentURL + user.idEstudiante;
    return this.http.put<EditProfileInterface>(url, user);
  }
 
}

 /*
  
  getUser(studentId: string): Observable<Student> {
    const url = this.baseURL + studentId;
    return this.http.get<Student>(url);
  }

  getUsers(): Observable<Student[]> {
    return this.http.get<Student[]>(this.baseURL);
  }

  getUsersWithHeaders(): Observable<any> {
    return this.http.get(this.baseURL, {observe: 'response'});
  }

  getUsersSendHeaders() {
     // headers HTTP
     let headers = new HttpHeaders();
     headers = headers.append('Authorization', 'bearer token2');
     headers = headers.append('X-Pagination', '3');
 
     // query strings
     let params = new HttpParams();
     params = params.append('X-Pagination', '4');
 
     return this.http.get<Student[]>(this.baseURL, {headers, params});
  }

  createUser(user: Student): Observable<Student>{
    return this.http.post<Student>(this.baseURL, user);
  }

  updateUser(user: Student): Observable<Student> {
    const url = this.baseURL + student.id;
    return this.http.put<Student>(url, user);
  }

  patchUser(id: number, operations: Operation[]){
    const url = this.baseURL + id;
    return this.http.patch(url, operations);
  }

  deleteUser(id: number): Observable<any> {
    const url = this.baseURL + id;
    return this.http.delete(url);
  }*/

/*
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

  
  patchPerson(id: number, operations: Operation[]){
    const url = this.baseURL + id;
    return this.http.patch(url, operations);
  }
  

 deletePerson(id: number): Observable<any> {
  const url = this.baseURL + id;
  return this.http.delete(url);
}
*/
