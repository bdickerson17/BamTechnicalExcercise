import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HeaderComponent } from './components/header/header.component';
import { FooterComponent } from './components/footer/footer.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatButtonModule } from '@angular/material/button';
import { MatTableModule } from '@angular/material/table';
import { MatIconModule } from '@angular/material/icon';
import { MatExpansionModule } from '@angular/material/expansion';
import { AllAstronautDashboardComponent } from './components/all-astronaut-dashboard/all-astronaut-dashboard.component';
import { ActsAPIService } from './services/acts-api.service';
import { HttpClientModule } from '@angular/common/http';
import { NoDataPlaceholderComponent } from './components/no-data-placeholder/no-data-placeholder.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AllAstronautDashboardComponent,
    NoDataPlaceholderComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatExpansionModule,
    HttpClientModule
  ],
  providers: [ActsAPIService],
  bootstrap: [AppComponent]
})
export class AppModule { }
