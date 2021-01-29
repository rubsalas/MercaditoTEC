import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public idEstudiante!: string | null;

  public idCursoTutor!: string | null;
  public nameCursoTutor!: string | null;
  
  public idPracticaTutor!: string | null;
  public nombrePracticaTutor!: string | null;
  
  showGuide = true; // Cuando ya se mostró se cambia y no se vuelve hacer la petición al API 
  currentUser = new BehaviorSubject(this.user);

  constructor() { }

  set user(value: string) {
    this.currentUser.next(value); // this will make sure to tell every subscriber about the change.
    localStorage.setItem('currentUser', value);
  }

  get user() {
    var myuser = localStorage.getItem('currentUser');
    if(myuser != null){
      return myuser;
    }
    return 'null';
  }

  grabarId(id: string){
    localStorage.setItem("idEstudiante", id);
  }

  grabarCursoTutor(id: string, name: string){
    localStorage.setItem("nombreCursoTutor", name);
    localStorage.setItem("idCursoTutor", id);
  }

  grabarPracticeTutor(id: string, name: string){
    localStorage.setItem("nombrePracticaTutor", name);
    localStorage.setItem("idPracticaTutor", id);
  }

  loginUser(user: string) {
    localStorage.setItem("currentUser", user);
  }

  logoutUser() {
    localStorage.setItem("currentUser", 'nobody')
  }

  getCurrentUser(){
    return localStorage.getItem("currentUser");;
  }

  getIdStudent(){
    this.idEstudiante = localStorage.getItem("idEstudiante");
    return this.idEstudiante;
  }

  getIdCursoTutor(){
    this.idCursoTutor = localStorage.getItem("idCursoTutor");
    return this.idCursoTutor;
  }

  getNameCursoTutor(){
    this.nameCursoTutor = localStorage.getItem("nombreCursoTutor");
    return this.nameCursoTutor;
  }

  getIdPracticaTutor(){
    this.idPracticaTutor = localStorage.getItem("idPracticaTutor");
    return this.idPracticaTutor;
  }

  getNamePracticeTutor(){
    this.nombrePracticaTutor = localStorage.getItem("nombrePracticaTutor");
    return this.nombrePracticaTutor;
  }

}
