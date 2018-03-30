import { Injectable, Inject} from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';
import { catchError, map, tap } from 'rxjs/operators';
import { MessageService } from './message.service';
import { Appointment } from '../appointments/appointment.interface';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable()
export class AppointmentService {

  appointments: Appointment[];

  constructor(
    private http: HttpClient,
    private messageService: MessageService){ }
  
  /** GET appointments from the server */
  getAppointments(): Observable<Appointment[] > {
    return this.http.get<Appointment[]>('api/Appointment/Appointments/')
      .pipe(
      tap(appointments => this.log(`fetched appointments`)),
      catchError(this.handleError('getAppointments', []))
      );
  }

  //////// Save methods //////////

  /** POST: add a new apppointment to the server */
  addAppointment(appointment: Appointment): Observable<Appointment> {
    return this.http.post<Appointment>('api/Appointment/AddAppointment/', appointment, httpOptions).pipe(
      tap((appointment: Appointment) => this.log(`added appointment w/ ${appointment}`)),
      catchError(this.handleError<Appointment>('addAppointment'))
    );
  }
  /**
   * Handle Http operation that failed.
   * Let the app continue.
   * @param operation - name of the operation that failed
   * @param result - optional value to return as the observable result
   */
  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {

      // TODO: send the error to remote logging infrastructure
      console.error(error); // log to console instead

      // TODO: better job of transforming error for user consumption
      this.log(`${operation} failed: ${error.message}`);

      // Let the app keep running by returning an empty result.
      return of(result as T);
    };
  }
  /** Log a appointmentsService message with the MessageService */
  private log(message: string) {
    this.messageService.add('AppointmentService: ' + message);
  }
}
