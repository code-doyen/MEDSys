using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MEDSys.Api.Models
{
    public class ClientContext : DbContext
    {
        public DbSet<Client> Client { get; set; }
        public DbSet<ServiceLine> ServiceLine { get; set; }
        public DbSet<Staff> Staff { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=clients.db");
        }
    }

    public class Client
    {
        [Key]
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime Birthday { get; set; }
    }

    public class Staff
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Client.ID")]
        public int ClientID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Specialty { get; set; }
    }

    public class ServiceLine
    {
        [Key]
        public int ID { get; set; }
        [ForeignKey("Client.ID")]
        public int ClientID { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public string Rendered { get; set; }

    }
    //public virtual ICollection<Client> Appointment { get; set; }
}
