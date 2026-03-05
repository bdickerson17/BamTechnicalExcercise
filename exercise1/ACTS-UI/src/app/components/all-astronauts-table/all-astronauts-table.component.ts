import { Component, Input } from '@angular/core';
import { PersonAstronaut } from 'src/app/models/PersonAstronaut';

@Component({
  selector: 'app-all-astronauts-table',
  templateUrl: './all-astronauts-table.component.html',
  styleUrls: ['./all-astronauts-table.component.scss']
})
export class AllAstronautsTableComponent {
  displayedColumns: string[] = ['name', 'currentRank', 'currentDutyTitle', 'careerStartDate', 'careerEndDate', 'expand'];

  @Input() allAstronauts: PersonAstronaut[] = [];


  expandedRow: PersonAstronaut | null = null;
}
