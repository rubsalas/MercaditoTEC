import { Injectable } from '@angular/core';
import { BehaviorSubject } from 'rxjs';
import { Subject } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  public idEstudiante!: string | null;
  public isSearchCourseView!: string | null;
  public idCarrerSearch!: string | null;
  public idOfferSelect!: string | null;

  public idCursoTutor!: string | null;
  public nameCursoTutor!: string | null;
  public idPracticaTutor!: string | null;
  public namePracticaTutor!: string | null;

  public idCursoTutored!: string | null;
  public nameCursoTutored!: string | null;
  public idPracticaTutored!: string | null;
  public namePracticaTutored!: string | null;
  public idCurseSearchTutored!: string | null;
  public nameCurseSearchTutored!: string | null;
  
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
  setSearchView(boolean: string){
    localStorage.setItem("isSearchCourseView", boolean);
  }
  getIsSearchView(){
    this.isSearchCourseView = localStorage.getItem("isSearchCourseView");
    return this.isSearchCourseView;
  }
  grabaridCarrerSearch(id: string){
    localStorage.setItem("idCarrerSearch", id);
  }
  getidCarrerSearch(){
    this.idCarrerSearch = localStorage.getItem("idCarrerSearch");
    return this.idCarrerSearch;
  }

  grabaridCarrerSelect(id: string){
    localStorage.setItem("idOfferSelect", id);
  }
  getidCarrerSelect(){
    this.idOfferSelect = localStorage.getItem("idOfferSelect");
    return this.idOfferSelect;
  }

  grabarCursoTutor(id: string, name: string){
    localStorage.setItem("nombreCursoTutor", name);
    localStorage.setItem("idCursoTutor", id);
  }
  grabarPracticeTutor(id: string, name: string){
    localStorage.setItem("nombrePracticaTutor", name);
    localStorage.setItem("idPracticaTutor", id);
  }

  grabarCursoTutored(id: string, name: string){
    localStorage.setItem("nombreCursoTutorado", name);
    localStorage.setItem("idCursoTutorado", id);
  }
  grabarPracticeTutored(id: string, name: string){
    localStorage.setItem("nombrePracticaTutorado", name);
    localStorage.setItem("idPracticaTutorado", id);
  }
  grabaridCurseSearchTutored(id: string){
    localStorage.setItem("idCursoBuscadoTutorado", id);
  }
  grabarCurseSearchTutored(id: string, name: string){
    localStorage.setItem("nombreCursoBuscadoTutorado", name);
    localStorage.setItem("idCursoBuscadoTutorado", id);
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
    this.namePracticaTutor = localStorage.getItem("nombrePracticaTutor");
    return this.namePracticaTutor;
  }

  getIdCursoTutored(){
    this.idCursoTutor = localStorage.getItem("idCursoTutorado");
    return this.idCursoTutor;
  }
  getNameCursoTutored(){
    this.nameCursoTutor = localStorage.getItem("nombreCursoTutorado");
    return this.nameCursoTutor;
  }

  getIdPracticaTutored(){
    this.idPracticaTutor = localStorage.getItem("idPracticaTutorado");
    return this.idPracticaTutor;
  }
  getNamePracticeTutored(){
    this.namePracticaTutor = localStorage.getItem("nombrePracticaTutorado");
    return this.namePracticaTutor;
  }

  getidCurseSearchTutored(){
    this.idCurseSearchTutored = localStorage.getItem("idCursoBuscadoTutorado");
    return this.idCurseSearchTutored;
  }
  getNameCurseSearchTutored(){
    this.nameCurseSearchTutored = localStorage.getItem("nombreCursoBuscadoTutorado");
    return this.nameCurseSearchTutored;
  }

}
