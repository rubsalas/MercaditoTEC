import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { DaticInterface } from '../modelos/datic-interface';

@Injectable({
  providedIn: 'root'
})
export class DaticService {

  baseURL = environment.apiURL + 'datic/';
  constructor(private http: HttpClient) { }

  postDatic(data: DaticInterface) {
    this.http.post(this.baseURL, data)
    .subscribe( newDatic => {
      console.log(newDatic);
    });
  }

}

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
