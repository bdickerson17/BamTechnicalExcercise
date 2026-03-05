// DTO for creating a new Astronaut Duty
export interface CreateAstronautDuty {
  name: string;          // required person name to associate duty with
  rank: string;          // required
  dutyTitle: string;     // required
  dutyStartDate: Date;   // required
}
