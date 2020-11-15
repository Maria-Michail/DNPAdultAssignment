using WebApi.Models;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Persistence{  
public class AdultContext : DbContext
    {
        public DbSet<Adult> Adults { get; set; }
        public DbSet<User> Users { get; set; }
        
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) {
            // name of database
            optionsBuilder.UseSqlite(@"Data Source = C:\Users\maria\OneDrive\Documents\.NET\DNPAdultsAssignment\WebApi\Adults.db");
            optionsBuilder.EnableSensitiveDataLogging();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Adult>().HasKey(fam => new {fam.Id});
            modelBuilder.Entity<User>().HasKey(us => new {us.username});
        }

        
    }
}