import { Component, OnInit } from '@angular/core';
import { CourseTutoredInterface } from 'src/app/models/course-tutored-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { TutoredService } from 'src/app/services/tutored.service';
import { Location } from '@angular/common';
import { CourseLibraryInterface } from 'src/app/models/course-library-interface';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';

@Component({
  selector: 'app-search-results',
  templateUrl: './search-results.component.html',
  styleUrls: ['./search-results.component.scss']
})
export class SearchResultsComponent implements OnInit {

  public coursesList!: CourseTutorInterface[];
  public coursesLibrary: CourseLibraryInterface[] | undefined;

  notFound = false;
  public searchCourse = '';

  constructor(public tutoredService: TutoredService,
    public authService: AuthService, 
    private router: Router,
    private location: Location) { }

  ngOnInit(): void {
    this.getListCourses();
    this.loadCoursesLibrary();
  }

  getListCourses(): void {

    this.tutoredService
      .getAllSearchCourses(this.authService.getidCurseSearchTutored())
      .subscribe( (courses: any) => {
        (this.coursesList = courses)
        console.log(this.coursesList);
      });
  }

  openCourse(course: CourseTutorInterface){
    console.log(course);
    this.authService.setSearchView('true');
    this.authService.grabarCursoTutor(course.idCursoTutor.toString(),course.nombreCurso);
    this.router.navigateByUrl('/searchCourseDetails');
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
    location.reload();
  }

}



