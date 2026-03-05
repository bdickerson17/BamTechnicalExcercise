import { PersonAstronaut } from "./PersonAstronaut";

export interface ApiResponse {
  message: string;
  success: boolean;
  responseCode: number;
}
//TODO: break iterfaces into separate files for better organization and maintainability
export interface AllPeopleResponse extends ApiResponse {
  people: PersonAstronaut[];
}


export interface PersonByNameResponse extends ApiResponse {
  person: PersonAstronaut;
}

export interface CreatePersonResponse extends ApiResponse {
  id: number;
}
