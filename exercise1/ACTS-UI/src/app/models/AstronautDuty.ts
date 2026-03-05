import { PersonAstronaut } from './PersonAstronaut';

export class AstronautDuty {
  id: number;
  personId: number;            // optional if duty can exist without assignment
  rank: string;
  dutyTitle: string;
  dutyStartDate: Date;
  dutyEndDate?: Date | null;

  constructor(
    id: number = 0,
    rank: string = '',
    dutyTitle: string = '',
    dutyStartDate: Date = new Date(),
    personId: number,
    dutyEndDate?: Date | null,
  ) {
    this.id = id;
    this.personId = personId;
    this.rank = rank;
    this.dutyTitle = dutyTitle;
    this.dutyStartDate = dutyStartDate;
    this.dutyEndDate = dutyEndDate;
  }
}
