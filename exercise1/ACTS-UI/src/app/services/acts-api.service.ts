import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { PersonAstronaut } from '../models/PersonAstronaut';
import { AllPeopleResponse, CreatePersonResponse, PersonByNameResponse } from '../models/ApiResponse';

@Injectable({
  providedIn: 'root'
})
export class ActsAPIService {

  private baseApiUrl = 'https://localhost:7204/';

  constructor(private http: HttpClient) { }

  // Person Controller API collection

  getAstronauts(): Observable<PersonAstronaut[]> {
    const url = this.baseApiUrl + 'Person';
    return this.http.get<AllPeopleResponse>(url).pipe(
      map(response => {
        if (response.success) {
          return response.people;
        } else {
          throw new Error(response.message);
        }
      })
    );
  }

  GetPersonByName(name: string): Observable<PersonAstronaut> {
    const url = `${this.baseApiUrl}Person/${name}`;

    return this.http.get<PersonByNameResponse>(url).pipe(
      map(response => {
        if (response.success) {
          return response.person;
        } else {
          throw new Error(response.message);
        }
      })
    );
  }

  CreatePerson(name: string): Observable<number> {
    const url = `${this.baseApiUrl}Person/CreatePerson/${name}`;

    return this.http.post<CreatePersonResponse>(url, { name }).pipe(
      map(response => {
        if (response.success) {
          return response.id;
        } else {
          throw new Error(response.message);
        }
      })
    );
  }

  // Astronaut Duty Controller API collection

}
