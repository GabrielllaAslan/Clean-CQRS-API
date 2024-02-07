using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Database
{
    public class RealDatabase : DbContext
    {
        public RealDatabase()
        {

        }

        public RealDatabase(DbContextOptions<RealDatabase> options) : base(options)
        {

        }

        public DbSet<Dog> Dogs { get; set; }
        /*
        public DbSet<Cat> Cats { get; set; }
        public DbSet<Bird> Birds { get; set; }
        */

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=LAPTOP-O7CREI7D; Database=claen-api-database; Trusted_Connection=True; TrustServerCertificate=True");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
