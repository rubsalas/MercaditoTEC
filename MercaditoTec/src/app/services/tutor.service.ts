import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseTutorInterface } from '../models/course-tutor-interface';
import { AddCourseInterface } from '../models/add-course-interface';
import { CourseLibraryInterface } from '../models/course-library-interface';
import { PracticeTutorInterface } from '../models/practice-tutor-interface';

@Injectable({
  providedIn: 'root'
})
export class TutorService {

  /*  LISTA DE URLS PARA LOS REQUESTS HTTP   */
  listCoursesURL = environment.apiURL + 'cursosTutorJ/Estudiante/';
  courseURL = environment.apiURL + 'cursosTutorJ/';

  practiceURL = environment.apiURL + 'practicasTutorJ/';
  listPracticesURL = environment.apiURL + 'practicasTutorJ/CursoTutor/';

  addCourseURL = environment.apiURL + 'cursosTutorJ';
  coursesLibraryURL = environment.apiURL + 'cursosJ';

  constructor(private http: HttpClient) { }

  getCoursesLibrary(): Observable<CourseLibraryInterface[]>{
    console.log('SOLICITAR BIBLIOTECA DE CURSOS: '+ this.coursesLibraryURL)
    return this.http.get<CourseLibraryInterface[]>(this.coursesLibraryURL);
  }

  getTutorCourse(idCursoTutor: string): Observable<CourseTutorInterface> {
    const url = this.courseURL + idCursoTutor;
    return this.http.get<CourseTutorInterface>(url);
  }

  getAllTutorCourses(idTutor: string | null): Observable<CourseTutorInterface[]>{
    let url = this.listCoursesURL + idTutor;
    console.log('SOLICITAR CURSOS DEL TUTOR: '+ url)
    return this.http.get<CourseTutorInterface[]>(url);
  }

  getTutorPractice(tutorPracticeId: string): Observable<PracticeTutorInterface> {
    const url = this.practiceURL + tutorPracticeId;
    return this.http.get<PracticeTutorInterface>(url);
  }

  getAllTutorPractices(idCursoTutor: string | null): Observable<PracticeTutorInterface[]>{
    let url = this.listPracticesURL + idCursoTutor;
    console.log('SOLICITAR PRACTICAS DEL CURSO DE TUTOR: '+ url)
    return this.http.get<PracticeTutorInterface[]>(url);
  }

  addTutorCourse(data: AddCourseInterface): Observable<AddCourseInterface> {
    return this.http.post<AddCourseInterface>(this.addCourseURL, data);
  }

}
