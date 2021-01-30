import { Component, OnInit } from '@angular/core';
import { TutorService } from 'src/app/services/tutor.service';
import { CourseTutorInterface } from 'src/app/models/course-tutor-interface';
import { NgForm } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';
import { Router } from '@angular/router';
import { PracticeTutorInterface } from 'src/app/models/practice-tutor-interface';

@Component({
  selector: 'app-practices-tutored-list',
  templateUrl: './practices-tutored-list.component.html',
  styleUrls: ['./practices-tutored-list.component.scss']
})
export class PracticesTutoredListComponent implements OnInit {

  public practicesList!: PracticeTutorInterface[];
  public courseName = '';
  public searchView!: string | null;

  constructor(public tutorService: TutorService, 
    public authService: AuthService, 
    private router: Router) { }

  ngOnInit(): void {
    this.searchView = this.authService.getIsSearchView();
    this.getListPractices();
  }

  getListPractices(): void {
    this.tutorService
      .getAllTutorPractices(this.authService.getIdCursoTutor())
      .subscribe( (practices: any) => {
        (this.practicesList = practices)
        console.log(this.practicesList);
      });
  }

  openPractice(practice: PracticeTutorInterface){
    console.log(practice);
    this.authService.grabarPracticeTutor(practice.idPracticaTutor.toString(), practice.nombre);
    this.router.navigateByUrl('/practiceTutoredDetails');
  }

}
