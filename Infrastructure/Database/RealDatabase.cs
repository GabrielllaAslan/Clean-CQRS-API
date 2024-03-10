using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public virtual DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public virtual DbSet<Cat> Cats { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAnimal> UserAnimals { get; set; }
       
        public RealDatabase()
        {

        }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {

        }
 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-O7CREI7D; Database=claen-api; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera många-till-många-relationen mellan User och AnimalModel via UserAnimal
            modelBuilder.Entity<UserAnimal>()
                .HasKey(ua => new { ua.UserId, ua.AnimalId });

           

            base.OnModelCreating(modelBuilder);

            SeedDB.SeedAnimals(modelBuilder);
        }

    }
}
