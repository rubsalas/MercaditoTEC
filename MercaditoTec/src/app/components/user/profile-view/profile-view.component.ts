import { Component, OnInit } from '@angular/core';
import { StudentInterface } from 'src/app/models/student-interface';
import { AuthService } from 'src/app/services/auth.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-profile-view',
  templateUrl: './profile-view.component.html',
  styleUrls: ['./profile-view.component.scss']
})
export class ProfileViewComponent implements OnInit {

  notFound = false;
  student: StudentInterface | undefined;

  constructor(public studentService: StudentService, public authService: AuthService) { }

  ngOnInit(): void {
    var id = this.authService.getIdStudent();
    this.getStudent(id);
  }

  getStudent(studentId: string | null) {
      this.notFound = false;

      this.studentService.getProfileStudent(studentId)
      .subscribe((studentFromTheAPI : any) => {
        this.student = studentFromTheAPI;
      });
    }

}
