export interface Appointment {
  appointmentID: number,
  clientName: string,
  clientLastName: string,
  clientBirthday: string,
  staffName: string,
  staffLastName: string,
  staffSpecialty: string,
  serviceLine: string,
  serviceLineStartDate: DateTimeFormat,
  serviceLineEndDate: DateTimeFormat
}
