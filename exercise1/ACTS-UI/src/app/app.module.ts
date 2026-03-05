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
import { ReactiveFormsModule } from '@angular/forms';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { AllAstronautDashboardComponent } from './components/all-astronaut-dashboard/all-astronaut-dashboard.component';
import { ActsAPIService } from './services/acts-api.service';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { MatProgressSpinnerModule } from '@angular/material/progress-spinner';
import { HttpClientModule } from '@angular/common/http';
import { MatExpansionModule } from '@angular/material/expansion';
import { HttpLoadingInterceptor } from './interceptors/http-loading.interceptor';
import { ErrorHandlingInterceptor } from './interceptors/error-handling.interceptor';
import { NoDataPlaceholderComponent } from './components/no-data-placeholder/no-data-placeholder.component';
import { AllAstronautsTableComponent } from './components/all-astronauts-table/all-astronauts-table.component';
import { NewPersonDialogComponent } from './components/new-person-dialog/new-person-dialog.component';
import { MatDialogModule } from '@angular/material/dialog';
import { MatSnackBarModule } from '@angular/material/snack-bar';
import { NewAstronautDutyDialogComponent } from './components/new-astronaut-duty-dialog/new-astronaut-duty-dialog.component';
import { AllAstronautDutiesListedComponent } from './components/all-astronaut-duties-listed/all-astronaut-duties-listed.component';

@NgModule({
  declarations: [
    AppComponent,
    HeaderComponent,
    FooterComponent,
    AllAstronautDashboardComponent,
    NoDataPlaceholderComponent,
    AllAstronautsTableComponent,
    NewPersonDialogComponent,
    NewAstronautDutyDialogComponent,
    AllAstronautDutiesListedComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    MatButtonModule,
    MatTableModule,
    MatIconModule,
    MatExpansionModule,
    MatProgressSpinnerModule,
    MatSnackBarModule,
    HttpClientModule,
    MatDialogModule,
    ReactiveFormsModule,
    MatFormFieldModule,
    MatInputModule,
],
  providers: [
    ActsAPIService,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HttpLoadingInterceptor,
      multi: true
    },
    {
      provide: HTTP_INTERCEPTORS,
      useClass: ErrorHandlingInterceptor,
      multi: true
    }
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
