export class PersonAstronaut {
  personId: number;
  name: string = '';
  currentRank: string = '';
  currentDutyTitle: string = '';
  careerStartDate?: Date;
  careerEndDate?: Date;

  constructor(
    personId: number = 0,
    name: string = '',
    currentRank: string = '',
    currentDutyTitle: string = '',
    careerStartDate?: Date,
    careerEndDate?: Date
  ) {
    this.personId = personId;
    this.name = name;
    this.currentRank = currentRank;
    this.currentDutyTitle = currentDutyTitle;
    this.careerStartDate = careerStartDate;
    this.careerEndDate = careerEndDate;
  }
}
