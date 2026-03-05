import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, map } from 'rxjs';
import { PersonAstronaut } from '../models/PersonAstronaut';
import { AllPeopleResponse } from '../models/ApiResponse';

@Injectable({
  providedIn: 'root'
})
export class ActsAPIService {

  private baseApiUrl = 'https://localhost:7204/';

  constructor(private http: HttpClient) { }

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
}
