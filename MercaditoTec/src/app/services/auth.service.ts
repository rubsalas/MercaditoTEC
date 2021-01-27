import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AuthService {

  currentUser!: string | null;
  idEstudiante = '';
  showGuide = true; // Cuando ya se mostró se cambia y no se vuelve hacer la petición al API 

  constructor() { 

  }

  grabarId(id: string){
    localStorage.setItem("idEstudiante", id);
  }

  loginUser(user: string) {
    localStorage.setItem("currentUser", user);
  }

  logoutUser() {
    this.currentUser = 'nobody';
    localStorage.setItem("currentUser", 'nobody')
  }

  getCurrentUser(){
    this.currentUser = localStorage.getItem("currentUser");
    return this.currentUser;
  }

}
