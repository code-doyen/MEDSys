import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';

import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { AppointmentsComponent } from './appointments/appointments.component';
import { AppointmentService } from './services/appointment.service';
import { MessageService } from './services/message.service';
import { AppointmentFormReactiveComponent } from './appointment-form-reactive/appointment-form-reactive.component';
import { ForbiddenValidatorDirective } from './directives/forbidden-name.directive';
import { ScheduleComponent } from './schedule/schedule.component';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    AppointmentsComponent,
    AppointmentFormReactiveComponent,
    ForbiddenValidatorDirective,
    ScheduleComponent
  ],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    RouterModule.forRoot([
      { path: '', component: HomeComponent, pathMatch: 'full' },
      { path: 'schedule', component: ScheduleComponent },
      { path: 'appointments', component: AppointmentsComponent }
    ])
  ],
  providers: [AppointmentService, MessageService],
  bootstrap: [AppComponent]
})
export class AppModule { }
