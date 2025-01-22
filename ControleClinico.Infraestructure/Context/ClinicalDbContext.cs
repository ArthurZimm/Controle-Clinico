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
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=clinical-database;Username=root;Password=1234");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Patient>()
                .OwnsOne(p => p.Address);
        }
        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<Address> Addresses { get; set; }
    }
}