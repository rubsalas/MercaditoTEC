import { Component, OnInit } from '@angular/core';
import { Person } from 'src/app/modelos/person';
import { PersonService } from 'src/app/services/person.service';

@Component({
  selector: 'app-admin-view',
  templateUrl: './admin-view.component.html',
  styleUrls: ['./admin-view.component.scss']
})
export class AdminViewComponent implements OnInit {

  notFound = false;
  person: Person | undefined; 

  constructor(private personService: PersonService) { }

  ngOnInit() {
  }

  getPerson(personId: string) {
    this.notFound = false;
    //this.person = null;

    this.personService.getPerson(personId).subscribe((personFromTheAPI : Person) => {
      this.person = personFromTheAPI;
    }, (err: any) => {
      console.error(err);
      this.notFound = true;
    });
  }

}
