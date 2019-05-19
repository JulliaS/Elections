using Microsoft.EntityFrameworkCore;
using Vybory.Models;

namespace Vybory
{
    public class ElectionsContext : DbContext
    {
        public ElectionsContext(DbContextOptions<ElectionsContext> options)
            : base(options)
        { }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<Appeal> Appeals { get; set; }
        public DbSet<AppealType> AppealTypes { get; set; }
        public DbSet<Candidat> Candidats { get; set; }
        public DbSet<ChermanOfDistrict> ChermanOfDistricts { get; set; }
        public DbSet<ChermanOfPollingStation> ChermanOfPollingStations { get; set; }
        public DbSet<Citizen> Citizens { get; set; }
        public DbSet<Complaint> Complaints { get; set; }
        public DbSet<ComplaintType> ComplaintTypes { get; set; }
        public DbSet<District> Districts { get; set; }
        public DbSet<Election> Elections { get; set; }
        public DbSet<Observer> Observers { get; set; }
        public DbSet<PollingStation> PollingStations { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Status> Statuses { get; set; }
        public DbSet<Tour> Tours { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Vote> Votes { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host = localhost; Port = 5432; Database = Votes; Username = postgres; Password = password");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasAlternateKey(u => u.IPN);
            modelBuilder.Entity<District>().HasAlternateKey(u => u.Number);
            modelBuilder.Entity<District>().HasAlternateKey(u => u.Name);
            modelBuilder.Entity<PollingStation>().HasAlternateKey(u => u.Name);
            modelBuilder.Entity<PollingStation>().HasAlternateKey(u => u.Number);
            modelBuilder.Entity<Candidat>().HasAlternateKey(u => u.Number);
        }
    }
}
