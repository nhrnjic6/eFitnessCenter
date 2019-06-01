using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RS2_Seminarski.Database
{
    public class FitnessCenterDbContext : DbContext
    {
        public FitnessCenterDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<AppUser> AppUsers { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Employee> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AppUser>()
                .HasOne<Client>()
                .WithOne(c => c.AppUser)
                .HasForeignKey<Client>(b => b.AppUserId);

            modelBuilder.Entity<AppUser>()
                .HasOne<Employee>()
                .WithOne(e => e.AppUser)
                .HasForeignKey<Employee>(e => e.AppUserId);
        }
    }
}
