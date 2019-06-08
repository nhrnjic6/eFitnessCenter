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
        public DbSet<MembershipPayment> MembershipPayments { get; set; }
        public DbSet<MembershipType> MembershipTypes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Client>()
                .HasIndex(c => c.AppUserId)
                .IsUnique(true);

            modelBuilder.Entity<Employee>()
                .HasIndex(c => c.AppUserId)
                .IsUnique(true);

            modelBuilder.Entity<MembershipType>()
                .HasData(
                    new MembershipType { Id = 1, MonthsValid = 1, Price = 40, Name = "Jedan Mjesec" },
                    new MembershipType { Id = 2, MonthsValid = 2, Price = 70, Name = "Dva Mjeseca" },
                    new MembershipType { Id = 3, MonthsValid = 6, Price = 110, Name = "Sest Mjeseci" },
                    new MembershipType { Id = 4, MonthsValid = 12, Price = 180, Name = "Godisnja Clanarina" }
                );

            modelBuilder.Entity<MembershipPayment>()
                .HasOne(x => x.Employee)
                .WithMany(x => x.MembershipPayments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<MembershipPayment>()
                .HasOne(x => x.Client)
                .WithMany(x => x.MembershipPayments)
                .IsRequired()
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
