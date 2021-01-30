import { Component, OnInit } from '@angular/core';
import { CourseTutoredInterface } from 'src/app/models/course-tutored-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { TutoredService } from 'src/app/services/tutored.service';
import { CourseLibraryInterface } from 'src/app/models/course-library-interface';

@Component({
  selector: 'app-tutored-view',
  templateUrl: './tutored-view.component.html',
  styleUrls: ['./tutored-view.component.scss']
})
export class TutoredViewComponent implements OnInit {

  public coursesList!: CourseTutoredInterface[];
  public coursesLibrary: CourseLibraryInterface[] | undefined;

  notFound = false;
  public searchCourse = '';

  constructor(public tutoredService: TutoredService,
    public authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    this.getListCourses();
    this.loadCoursesLibrary();
  }

  getListCourses(): void {
    this.tutoredService
      .getAllTutoredCourses(this.authService.getIdStudent())
      .subscribe( (courses: any) => {
        (this.coursesList = courses)
        console.log(this.coursesList);
      });
  }

  openCourse(course: CourseTutoredInterface){
    console.log(course);
    this.authService.setSearchView('false');
    this.authService.grabarCursoTutor(course.idCursoTutorado.toString(),course.nombreCurso);
    this.authService.grabarCursoTutored(course.idCursoTutorado.toString(),course.nombreCurso);
    this.router.navigateByUrl('/courseTutoredDetails');
  }

  loadCoursesLibrary(){
    this.tutoredService.getCoursesLibrary()
    .subscribe( (coursesFromApi: any) => {
      console.log(coursesFromApi)
      this.coursesLibrary = coursesFromApi;
    });
  }

  buscarCurso(){
    this.authService.grabaridCurseSearchTutored(this.searchCourse);
    this.router.navigateByUrl('/searchCurseResults');

  }

}



