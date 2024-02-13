using Domain.Models;
using Domain.Models.Animal;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public DbSet<AnimalModel> AnimalModels { get; set; }
        public DbSet<Bird> Birds { get; set; }
        public virtual DbSet<Dog> Dogs { get; set; }
        public DbSet<Cat> Cats { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public DbSet<UserAnimal> UserAnimals { get; set; }
       
        public RealDatabase()
        {

        }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {

        }
 
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-O7CREI7D; Database=claen-api-database; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Konfigurera många-till-många-relationen mellan User och AnimalModel via UserAnimal
            modelBuilder.Entity<UserAnimal>()
                .HasKey(ua => new { ua.UserId, ua.AnimalId });

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.User)
                .WithMany(u => u.UserAnimals)
                .HasForeignKey(ua => ua.UserId);

            modelBuilder.Entity<UserAnimal>()
                .HasOne(ua => ua.Animal)
                .WithMany(a => a.UserAnimals)
                .HasForeignKey(ua => ua.AnimalId);
            base.OnModelCreating(modelBuilder);
        }
    }
}
