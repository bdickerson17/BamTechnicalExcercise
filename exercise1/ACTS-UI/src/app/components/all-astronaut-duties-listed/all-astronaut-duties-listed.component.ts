import { Component, Input } from '@angular/core';
import { AstronautDuty } from '../../models/AstronautDuty';

@Component({
  selector: 'app-all-astronaut-duties-listed',
  templateUrl: './all-astronaut-duties-listed.component.html',
  styleUrls: ['./all-astronaut-duties-listed.component.scss']
})
export class AllAstronautDutiesListedComponent {
  @Input() duties: AstronautDuty[] = [];
}
