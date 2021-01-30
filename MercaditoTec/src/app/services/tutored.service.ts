import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CourseTutorInterface } from '../models/course-tutor-interface';
import { AddCourseInterface } from '../models/add-course-interface';
import { CourseLibraryInterface } from '../models/course-library-interface';
import { PracticeTutorInterface } from '../models/practice-tutor-interface';
import { CourseTutoredInterface } from '../models/course-tutored-interface';


@Injectable({
  providedIn: 'root'
})
export class TutoredService {

  /*  LISTA DE URLS PARA LOS REQUESTS HTTP   */
  listCoursesURL = environment.apiURL + 'cursosTutoradoJ/Tutorado/';
  courseURL = environment.apiURL + 'cursosTutorJ/';
  searchCoursesURL = environment.apiURL + 'cursosTutorJ/Curso/';

  //practiceURL = environment.apiURL + 'practicasTutorJ/';
  //listPracticesURL = environment.apiURL + 'practicasTutorJ/CursoTutor/';

  coursesLibrary = environment.apiURL + 'cursosJ';

  constructor(private http: HttpClient) { }

  getCoursesLibrary(): Observable<CourseLibraryInterface[]>{
    console.log('SOLICITAR BIBLIOTECA DE CURSOS: '+ this.coursesLibrary)
    return this.http.get<CourseLibraryInterface[]>(this.coursesLibrary);
  }

  getTutoredCourse(idCursoTutored: string): Observable<CourseTutoredInterface> {
    const url = this.courseURL + idCursoTutored;
    return this.http.get<CourseTutoredInterface>(url);
  }

  getAllTutoredCourses(idTutored: string | null): Observable<CourseTutoredInterface[]>{
    let url = this.listCoursesURL + idTutored;
    console.log('SOLICITAR CURSOS DEL TUTOR: '+ url)
    return this.http.get<CourseTutoredInterface[]>(url);
  }

  getAllSearchCourses(idCurso: string | null): Observable<CourseTutorInterface[]>{
    let url = this.searchCoursesURL + idCurso;
    console.log('BUSCAR CURSOS DEL TUTOR: '+ url)
    return this.http.get<CourseTutorInterface[]>(url);
  }

  /*getTutoredPractice(tutorPracticeId: string): Observable<PracticeTutorInterface> {
    const url = this.practiceURL + tutorPracticeId;
    return this.http.get<PracticeTutorInterface>(url);
  }

  getAllTutoredPractices(idCursoTutor: string | null): Observable<PracticeTutorInterface[]>{
    let url = this.listPracticesURL + idCursoTutor;
    console.log('SOLICITAR PRACTICAS DEL CURSO DE TUTOR: '+ url)
    return this.http.get<PracticeTutorInterface[]>(url);
  }

  addTutoredCourse(data: AddCourseInterface): Observable<AddCourseInterface> {
    return this.http.post<AddCourseInterface>(this.addCourseURL, data);
  }*/
}
