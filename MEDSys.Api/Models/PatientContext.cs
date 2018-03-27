using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MEDSys.Api.Models
{
    public class PatientContext : DbContext
    {
        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<Client> Client { get; set; }
        public DbSet<ServiceLine> ServiceLine { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clients.db");
        }
    }


    public class Appointment
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Client.ID")]
        public int ClientID { get; set; }
        [ForeignKey("Staff.ID")]
        public int StaffID { get; set; }
        [ForeignKey("Service.ID")]
        public int ServiceLineID { get; set; }
    }

    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[Display(Name = "End Time")]
        public DateTime Birthday { get; set; }
        //public virtual ICollection<Appointment> Appointment { get; set; }
    }

    public class Staff
    {
        [Key]
        public int ID { get; set; }
        //[ForeignKey("Appointment.ClientID")]
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
        //public virtual ICollection<Client> Appointment { get; set; }
    }

    public class ServiceLine
    {
        [Key]
        public int ID { get; set; }
        [DataType(DataType.Date)]      
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Time")]
        public DateTime StartTime { get; set; }
        [DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Time")]
        public DateTime EndTime { get; set; }
        //public virtual ICollection<Client> Appointment { get; set; }
    }

}
