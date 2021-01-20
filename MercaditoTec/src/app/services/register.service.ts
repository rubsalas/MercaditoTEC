import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { RegisterInterface } from '../models/register-interface';

@Injectable({
  providedIn: 'root'
})
export class RegisterService {

  baseURL = environment.apiURL + 'estudiantesJ/Registro/';
  constructor(private http: HttpClient) { }

  postRegister(data: RegisterInterface) {
    this.http.post(this.baseURL, data)
    .subscribe( newRegister => {
      console.log(newRegister);
    });
  }

}
