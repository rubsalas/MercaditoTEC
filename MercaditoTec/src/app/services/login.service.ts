import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { LoginInterface } from '../models/login-interface';
import { RegisterInterface } from '../models/register-interface';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class LoginService {

  daticURL = environment.apiURL + 'datic/';
  registerURL = environment.apiURL + 'estudiantesJ/Registro/';
  loginURL = environment.apiURL + 'estudiantesJ/Login';

  //private datic$ = new Subject<LoginInterface[]>();


  constructor(private http: HttpClient) { }

  /* Función para realizar un POST y verificar correo y contraseña
  con la base de datos de DATIC */
  postDatic(data: LoginInterface) {
    return this.http.post(this.daticURL, data);
  }

  /* Función para realizar un POST y hacerla petición de registrar un 
  nuevo usuario a MercaditoTEC */
  postRegister(data: RegisterInterface) {
    return this.http.post(this.registerURL, data);
  }

  /* Función para realizar un POST y verificar correo y contraseña
  con la base de datos de MercaditoTEC */
  postLogin(data: LoginInterface) {
    return this.http.post(this.loginURL, data);
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
