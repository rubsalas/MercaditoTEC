import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LoginInterface } from '../models/login-interface';
import { RegisterInterface } from '../models/register-interface';
import { Subject } from 'rxjs';
import { AdminInterface } from '../models/admin-interface';
import { Observable } from 'rxjs/internal/Observable';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  daticURL = environment.apiURL + 'datic/';
  registerURL = environment.apiURL + 'estudiantesJ/Registro/';
  loginURL = environment.apiURL + 'estudiantesJ/Login';
  loginAdminURL = environment.apiURL + 'administradoresJ/Login';

  //private datic$ = new Subject<LoginInterface[]>();

  constructor(private http: HttpClient) { }

  /* Función para realizar un POST y verificar correo y contraseña
  con la base de datos de DATIC */
  postDatic(data: LoginInterface): Observable<LoginInterface> {
    return this.http.post<LoginInterface>(this.daticURL, data);
  }

  /* Función para realizar un POST y hacerla petición de registrar un 
  nuevo usuario a MercaditoTEC */
  postRegister(data: RegisterInterface): Observable<LoginInterface>  {
    return this.http.post<LoginInterface>(this.registerURL, data);
  }

  /* Función para realizar un POST y verificar correo y contraseña
  con la base de datos de MercaditoTEC */
  postLogin(data: LoginInterface): Observable<LoginInterface> {
    return this.http.post<LoginInterface>(this.loginURL, data);
  }

  /* Función para realizar un POST y verificar correo y contraseña
  con la base de datos de MercaditoTEC */
  postLoginAdmin(data: AdminInterface): Observable<LoginInterface>  {
    return this.http.post<LoginInterface>(this.loginAdminURL, data);
  }

}



 /*
 
    .subscribe( getLogin => {
      console.log(getLogin);
    })
 */


/*

postPaciente(daticData: Datic) {
    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type':  'application/json'
      })
    };
    const body = {
      correoInstitucional: daticData.correoInstitucional,
      contrasena: daticData.contrasena,
    };
    this.http.post(this.constante.rutaURL + '/api/datic', body, httpOptions).toPromise();

  }

  httpPostExample() {

    this.http.post("https://mercaditotec.azurewebsites.net/api/datic/",
        {
            "correoInstitucional": "verrier@estudiantec.cr",
            "contrasena": "WhV18mbd03bm"
        })
        .subscribe(
            (val) => {
                console.log("POST call successful value returned in body", 
                            val);
            },
            response => {
                console.log("POST call in error", response);
            },
            () => {
                console.log("The POST observable is now completed.");
            });
  }

createPerson(data: Datic): Observable<Datic>{
    return this.http.post<Datic>(this.baseURL, data, this.httpOptions);
  }

createStudent(correo: string, password: string){
    return this.http.post<Datic>(this.baseURL, {
      correoInstitucional: correo, contrasena: password
    }).subscribe(
      (val) => {
        console.log("POST call successful value returned in body",
          ( response: any) => {
            console.log("POST call in error", response);
          },
          () => {
            console.log("The POST observable is now completed.");
          });
      });
  }
  
*/
