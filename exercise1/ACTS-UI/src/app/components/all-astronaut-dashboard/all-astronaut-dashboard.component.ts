import { Component } from '@angular/core';
import { PersonAstronaut } from '../../models/PersonAstronaut';

@Component({
  selector: 'app-all-astronaut-dashboard',
  templateUrl: './all-astronaut-dashboard.component.html',
  styleUrls: ['./all-astronaut-dashboard.component.scss']
})
export class AllAstronautDashboardComponent {
displayedColumns: string[] = ['name', 'currentRank', 'currentDutyTitle', 'careerStartDate', 'careerEndDate', 'expand'];
  dataSource: PersonAstronaut[] = [
    new PersonAstronaut(1, 'John Doe', 'Captain', 'Pilot', new Date('2020-01-01'), new Date('2025-01-01')),
    new PersonAstronaut(2, 'Jane Smith', 'Major', 'Engineer', new Date('2019-05-15'), undefined),
  ];

  expandedRow: PersonAstronaut | null = null;
}
