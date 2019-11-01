using Clinic.API.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Clinic.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }
        public DbSet<Nurse> Nurses { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Root> Roots { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Contract> Contracts { get; set; }
        public DbSet<MedArea> MedAreas { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<MedOffice> MedOffices { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Referral> Referrals { get; set; }
        public DbSet<Treatment> Treatments { get; set; }
        public DbSet<Prescription> Prescriptions { get; set; }
        public DbSet<Drug> Drugs { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            //builder.Entity<Doctor>().HasData(
            //    new Doctor(Guid.NewGuid(), "user1@o2.pl", "doctor", DateTime.UtcNow, "Jan", "", "", "", "", "", "", ""),
            //    new Doctor(Guid.NewGuid(), "user1@o2.pl", "doctor", DateTime.UtcNow, "Jan", "Kowalski", "", "", "", "", "", ""),
            //    new Doctor(Guid.NewGuid(), "user2@o2.pl", "doctor", DateTime.UtcNow, "Piotr", "Nowak", "", "", "", "", "", ""),
            //    new Doctor(Guid.NewGuid(), "user3@o2.pl", "doctor", DateTime.UtcNow, "Paweł", "Szczery", "", "", "", "", "", ""),
            //    new Doctor(Guid.NewGuid(), "user4@o2.pl", "doctor", DateTime.UtcNow, "Andrzej", "Kosień", "", "", "", "", "", "")
            //  );
        }


    }
}
