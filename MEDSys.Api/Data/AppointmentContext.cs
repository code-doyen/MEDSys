
using MEDSys.Api.Models;
using Microsoft.EntityFrameworkCore;


namespace MEDSys.Api.Data
{
    public class AppointmentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=MEDSys;Trusted_Connection=True;MultipleActiveResultSets=true");
            //optionsBuilder.UseSqlite("Data Source=..\\MEDSys.Api\\clients.db");
        }
        public DbSet<Appointment> AppointmentQueries { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Appointment>()
                .ToTable("Appointment")
                .HasKey(c => c.AppointmentID);

        }
    }
}
