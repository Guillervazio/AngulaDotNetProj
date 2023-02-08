import { Component,EventEmitter,Input, OnInit, Output } from '@angular/core';
import { Person } from 'src/app/models/person';
import { PersonService } from 'src/app/services/person.service';
@Component({
  selector: 'app-edit-person',
  templateUrl: './edit-person.component.html',
  styleUrls: ['./edit-person.component.css']
})
export class EditPersonComponent implements OnInit{

  @Input() person?:Person;
  @Output() personUpdated = new EventEmitter<Person[]>();
  constructor(private personService:PersonService){}

  ngOnInit(): void {
    
  }
  updatePerson(person:Person){
    this.personService
    .updatePerson(person)
    .subscribe((persons: Person[])=>this.personUpdated.emit(persons));
  };

  deletePerson(person:Person){
    this.personService
    .deletePerson(person)
    .subscribe((persons: Person[])=>this.personUpdated.emit(persons));
  };

  createPerson(person:Person){
    this.personService
    .savePerson(person)
    .subscribe((persons: Person[])=>this.personUpdated.emit(persons));
  };


}
