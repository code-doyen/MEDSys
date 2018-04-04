
using System;
using System.Collections.Generic;

namespace MEDSys.Api.Models
{
    public class Appointment
    {
        public int AppointmentID { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }
        public string ClientBirthday { get; set; }
        public string StaffName { get; set; }
        public string StaffLastName { get; set; }
        public string StaffSpecialty { get; set; }
        public string ServiceLine { get; set; }
        public DateTime ServiceLineStartDate { get; set; }
        public DateTime ServiceLineEndDate { get; set; }
    }
}
