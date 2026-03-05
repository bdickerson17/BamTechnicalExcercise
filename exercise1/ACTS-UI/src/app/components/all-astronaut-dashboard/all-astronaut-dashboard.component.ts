import { Component, OnInit } from '@angular/core';
import { PersonAstronaut } from '../../models/PersonAstronaut';
import { ActsAPIService } from 'src/app/services/acts-api.service';
import { MatDialog } from '@angular/material/dialog';
import { NewPersonDialogComponent } from '../new-person-dialog/new-person-dialog.component';

@Component({
  selector: 'app-all-astronaut-dashboard',
  templateUrl: './all-astronaut-dashboard.component.html',
  styleUrls: ['./all-astronaut-dashboard.component.scss']
})
export class AllAstronautDashboardComponent implements OnInit {

  displayedColumns: string[] = ['name', 'currentRank', 'currentDutyTitle', 'careerStartDate', 'careerEndDate', 'expand'];
  allAstronauts: PersonAstronaut[] = [];

  expandedRow: PersonAstronaut | null = null;

  constructor(private ActsAPIService: ActsAPIService, public dialog: MatDialog) { }

  ngOnInit(): void {
    this.ActsAPIService.getAstronauts().subscribe(astronauts => {
      this.allAstronauts = astronauts;
    });
  }

  openNewPersonDialog() {
    const dialogRef = this.dialog.open(NewPersonDialogComponent, {
      width: '400px'
    });

    dialogRef.afterClosed().subscribe(result => {
      if (result) {
        // Refresh the astronauts list
        this.ActsAPIService.getAstronauts().subscribe(astronauts => {
          this.allAstronauts = astronauts;
        });
      }
    });
  }
}
