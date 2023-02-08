import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Person } from '../models/person';
import { environment } from 'src/environments/environment';
@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private url= "Person";
  constructor(private http: HttpClient) { }

  public getPerson() : Observable<Person[]>{
  return this.http.get<Person[]>(`${environment.apiUrl}/${this.url}`);
  }

  public savePerson(person: Person) : Observable<Person[]>{
    return this.http.post<Person[]>(`${environment.apiUrl}/${this.url}`,
    person);
  }

  public deletePerson(person: Person) : Observable<Person[]>{
    return this.http.delete<Person[]>(`${environment.apiUrl}/${this.url}/${person.id}`);
  }

  public updatePerson(person: Person) : Observable<Person[]>{
    return this.http.put<Person[]>(`${environment.apiUrl}/${this.url}`,
    person);
  }
}
