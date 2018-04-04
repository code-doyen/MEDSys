/* tslint:disable: member-ordering forin */
import { Component, Input, OnInit } from '@angular/core';
import { DatePipe } from '@angular/common';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { forbiddenNameValidator } from '../directives/forbidden-name.directive';
import { Appointment } from '../appointments/appointment.interface';
import { AppointmentService } from '../services/appointment.service';

@Component({
  selector: 'app-appointment-form-reactive',
  templateUrl: './appointment-form-reactive.component.html',
  styleUrls: ['./appointment-form-reactive.component.css']
})
export class AppointmentFormReactiveComponent implements OnInit {
  private specialties = ['None', 'CPR', 'Geriatrics'];
  private birthdate: String;
  private appointmentForm: FormGroup;
 
  constructor(private appointmentService: AppointmentService) {  }

  ngOnInit(): void {
    this.appointmentForm = new FormGroup({
      'clientName': new FormControl('',[
        Validators.required,
        Validators.minLength(2),
        forbiddenNameValidator(/\bbob\b/i) // <-- Here's how you pass in the custom validator.
      ]),
      'clientLastName': new FormControl('',[
        Validators.required,
        Validators.minLength(2),
        forbiddenNameValidator(/\bbob\b/i) // <-- Here's how you pass in the custom validator.
      ]),
      'clientBirthday': new FormControl('',[Validators.required]),
      'staffName': new FormControl('',[
        Validators.required,
        Validators.minLength(2),
        forbiddenNameValidator(/\bbob\b/i) // <-- Here's how you pass in the custom validator.
      ]),
      'staffLastName': new FormControl('',[
        Validators.required,
        Validators.minLength(2),
        forbiddenNameValidator(/\bbob\b/i) // <-- Here's how you pass in the custom validator.
      ]),
      'staffSpecialty': new FormControl(this.specialties[0], [
        Validators.required,
        forbiddenNameValidator(/-/i) // <-- Here's how you pass in the custom validator.
      ]),
      'serviceLine': new FormControl('',[
        Validators.required,
        Validators.minLength(10)
      ]),
      'serviceLineStartDate': new FormControl('',[Validators.required]),
      'serviceLineEndDate': new FormControl('',[Validators.required])
    });
  }
 
  get clientName() { return this.appointmentForm.get('clientName'); }
  get clientLastName() { return this.appointmentForm.get('clientLastName'); }
  get clientBirthday() { return this.appointmentForm.get('clientBirthday'); }
  get staffName() { return this.appointmentForm.get('staffName'); }
  get staffLastName() { return this.appointmentForm.get('staffLastName'); }
  get staffSpecialty() { return this.appointmentForm.get('staffSpecialty'); }
  get serviceLine() { return this.appointmentForm.get('serviceLine'); }
  get serviceLineStartDate() { return this.appointmentForm.get('serviceLineStartDate'); }
  get serviceLineEndDate() { return this.appointmentForm.get('serviceLineEndDate'); }


  checkAge(): void {
    if (this.birthdate != null) {
      let b = this.birthdate.toString().split("-");
      let birthMonth = Number.parseInt(b[1]);
      let birthDay = Number.parseInt(b[2]);
      let birthYear = Number.parseInt(b[0]);
      let d = new Date();
      let currYear = d.getFullYear();
      let currMonth = d.getMonth();
      let currDay = d.getDate();
      let age = currYear - birthYear;
      if (currMonth < birthMonth - 1) {
        age--;
      }
      if (birthMonth - 1 == currMonth && currDay < birthDay) {
        age--;
      }
      if (age > 70) {
        this.appointmentForm.setControl(
          'staffSpecialty', new FormControl(this.specialties[2], [
            Validators.required,
            forbiddenNameValidator(/\bcpr\b|\bnone\b/i) // <-- Here's how you pass in the custom validator.
          ]));
        this.appointmentForm.markAsUntouched();
      }
      else {
        this.appointmentForm.setControl(
          'staffSpecialty', new FormControl(this.appointmentForm.get('staffSpecialty').value, [
          Validators.required,
          forbiddenNameValidator(/-/i), // <-- Here's how you pass in the custom validator.
        ]));
      }
    }
  }

  save(appointment : Appointment): void {
    if (!appointment) { return; }
      this.appointmentService.addAppointment(appointment as Appointment)
      .subscribe(appointment => appointment);
  }
}
