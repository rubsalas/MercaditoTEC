import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { Router } from '@angular/router';
import { EditProfileInterface } from 'src/app/models/edit-profile-interface';
import { AuthService } from 'src/app/services/auth.service';
import { StudentService } from 'src/app/services/student.service';

@Component({
  selector: 'app-edit-profile',
  templateUrl: './edit-profile.component.html',
  styleUrls: ['./edit-profile.component.scss']
})
export class EditProfileComponent implements OnInit {

  public editprofile: EditProfileInterface = {
    idEstudiante: 0,
    nombre: '',
    apellidos: '',
    telefono: ''
  };

  constructor(public authService: AuthService,
    public studentService: StudentService,
    private router: Router) { }

  ngOnInit(): void {

  }

  editProfile(form: NgForm){
    if (form.valid) {
      var myId = this.authService.getIdStudent();

      if(myId != null){
        this.editprofile.idEstudiante = parseInt(myId);
        
        console.log(this.editprofile);
        this.router.navigateByUrl('/profileview');
        /*
        this.studentService.updateProfileStudent(this.editprofile)
        .subscribe( (response: any) => {
          console.log(response)
          this.router.navigateByUrl('/profileview');
        });*/

      }
    }
  }
}
