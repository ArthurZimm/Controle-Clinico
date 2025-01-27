using ControleClinico.Domain.Entity;
using Microsoft.EntityFrameworkCore;

namespace ControleClinico.Infraestructure.Context
{
    public class ClinicalDbContext : DbContext
    {
        public ClinicalDbContext()
        {
            
        }
        public ClinicalDbContext(DbContextOptions<ClinicalDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .OwnsOne(p => p.Address);


            modelBuilder.Entity<Consultation>()
         .HasOne(c => c.Patient)
         .WithMany(p => p.Consultations)
         .HasForeignKey(c => c.PatientId)
         .OnDelete(DeleteBehavior.Restrict); 

            modelBuilder.Entity<Consultation>()
                .HasOne(c => c.Doctor)
                .WithMany(d => d.Consultations)
                .HasForeignKey(c => c.DoctorId)
                .OnDelete(DeleteBehavior.Restrict); 

        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<Consultation> Consultations { get; set; }
    }
}