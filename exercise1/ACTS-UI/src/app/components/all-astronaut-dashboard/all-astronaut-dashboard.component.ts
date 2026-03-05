import { Component, OnInit } from '@angular/core';
import { PersonAstronaut } from '../../models/PersonAstronaut';
import { ActsAPIService } from 'src/app/services/acts-api.service';

@Component({
  selector: 'app-all-astronaut-dashboard',
  templateUrl: './all-astronaut-dashboard.component.html',
  styleUrls: ['./all-astronaut-dashboard.component.scss']
})
export class AllAstronautDashboardComponent implements OnInit {

  displayedColumns: string[] = ['name', 'currentRank', 'currentDutyTitle', 'careerStartDate', 'careerEndDate', 'expand'];
  allAstronauts: PersonAstronaut[] = [];

  expandedRow: PersonAstronaut | null = null;

  constructor(private ActsAPIService: ActsAPIService) { }

    ngOnInit(): void {
      this.ActsAPIService.getAstronauts().subscribe(astronauts => {
        this.allAstronauts = astronauts;
      });
  }

}
