import { Component, OnInit } from '@angular/core';
import { AppointmentService } from '../services/appointment.service';
import { Appointment } from './appointment.interface';

@Component({
  selector: 'appointments',
  templateUrl: './appointments.component.html',
  styleUrls: ['./appointments.component.css']
})
export class AppointmentsComponent implements OnInit {

  private appointments: Appointment[];
  private appointment: Appointment;

  constructor(private appointmentService: AppointmentService) {  }

  ngOnInit() {
    this.getAppointments();
  }

  getAppointments(): void {
    this.appointmentService.getAppointments()
      .subscribe(appointments => this.appointments = appointments );
  }

}
