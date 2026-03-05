import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AllAstronautDashboardComponent } from './components/all-astronaut-dashboard/all-astronaut-dashboard.component';

const routes: Routes = [
  { path: '', component: AllAstronautDashboardComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
