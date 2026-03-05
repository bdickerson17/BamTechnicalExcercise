import { AstronautDuty } from "./AstronautDuty";

export class PersonAstronaut {
  personId: number;
  name: string = '';
  currentRank: string = '';
  currentDutyTitle: string = '';
  careerStartDate?: Date;
  careerEndDate?: Date;

  astronautDuties?: AstronautDuty[]; // optional navigation property for related duties

  constructor(
    personId: number = 0,
    name: string = '',
    currentRank: string = '',
    currentDutyTitle: string = '',
    careerStartDate?: Date,
    careerEndDate?: Date,
    astronautDuties?: AstronautDuty[]
  ) {
    this.personId = personId;
    this.name = name;
    this.currentRank = currentRank;
    this.currentDutyTitle = currentDutyTitle;
    this.careerStartDate = careerStartDate;
    this.careerEndDate = careerEndDate;
    this.astronautDuties = astronautDuties;
  }
}
