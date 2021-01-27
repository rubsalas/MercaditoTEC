import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { StudentInterface } from '../models/student-interface';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  studentURL = environment.apiURL + 'estudiantesJ/';
  constructor(private http: HttpClient) { }

  getStudent(studentId: string): Observable<StudentInterface> {
    const url = this.studentURL + studentId;
    return this.http.get<StudentInterface>(url);
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
