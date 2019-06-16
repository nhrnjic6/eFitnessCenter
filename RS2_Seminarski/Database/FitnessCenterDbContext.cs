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
        public DbSet<Suplement> Suplements { get; set; }
        public DbSet<SuplementType> SuplementTypes { get; set; }
        public DbSet<SuplementPayment> SuplementPayments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MembershipType>()
            .HasData(
                new MembershipType { Id = 1, MonthsValid = 1, Price = 40, Name = "Jedan Mjesec" },
                new MembershipType { Id = 2, MonthsValid = 2, Price = 70, Name = "Dva Mjeseca" },
                new MembershipType { Id = 3, MonthsValid = 6, Price = 110, Name = "Sest Mjeseci" },
                new MembershipType { Id = 4, MonthsValid = 12, Price = 180, Name = "Godisnja Clanarina" }
            );

            modelBuilder.Entity<SuplementType>()
                .HasData(
                    new SuplementType { Id = 1, Type = "Powder" },
                    new SuplementType { Id = 2, Type = "Capsule" },
                    new SuplementType { Id = 3, Type = "Softgels" },
                    new SuplementType { Id = 4, Type = "Liquids" }
                );
        }
    }
}
