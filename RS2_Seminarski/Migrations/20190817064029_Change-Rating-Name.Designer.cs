﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RS2_Seminarski.Database;

namespace RS2_Seminarski.Migrations
{
    [DbContext(typeof(FitnessCenterDbContext))]
    [Migration("20190817064029_Change-Rating-Name")]
    partial class ChangeRatingName
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.8-servicing-32085")
                .HasAnnotation("Relational:MaxIdentifierLength", 128)
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("RS2_Seminarski.Database.AppUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Address");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Email");

                    b.Property<string>("FirstName");

                    b.Property<string>("HashedPassword");

                    b.Property<string>("LastName");

                    b.Property<string>("PhoneNumber");

                    b.Property<int>("Status");

                    b.HasKey("Id");

                    b.ToTable("AppUsers");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Client", b =>
                {
                    b.Property<int?>("Id");

                    b.HasKey("Id");

                    b.ToTable("Clients");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Employee", b =>
                {
                    b.Property<int?>("Id");

                    b.Property<decimal>("Salary");

                    b.HasKey("Id");

                    b.ToTable("Employees");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.MembershipPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("MembershipTypeId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("MembershipTypeId");

                    b.ToTable("MembershipPayment");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.MembershipType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("MonthsValid");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.HasKey("Id");

                    b.ToTable("MembershipTypes");

                    b.HasData(
                        new { Id = 1, MonthsValid = 1, Name = "Jedan Mjesec", Price = 40.0 },
                        new { Id = 2, MonthsValid = 2, Name = "Dva Mjeseca", Price = 70.0 },
                        new { Id = 3, MonthsValid = 6, Name = "Sest Mjeseci", Price = 110.0 },
                        new { Id = 4, MonthsValid = 12, Name = "Godisnja Clanarina", Price = 180.0 }
                    );
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Suplement", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<double>("Amount");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("MessureUnit");

                    b.Property<string>("Name")
                        .IsRequired();

                    b.Property<double>("Price");

                    b.Property<int>("SuplementTypeId");

                    b.HasKey("Id");

                    b.HasIndex("SuplementTypeId");

                    b.ToTable("Suplements");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.SuplementPayment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("Amount");

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<int?>("EmployeeId");

                    b.Property<int?>("SuplementId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("EmployeeId");

                    b.HasIndex("SuplementId");

                    b.ToTable("SuplementPayment");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.SuplementsRating", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("ClientId");

                    b.Property<int>("Rating");

                    b.Property<int>("SuplementId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("SuplementId");

                    b.ToTable("SuplementsRatings");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.SuplementType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Type");

                    b.HasKey("Id");

                    b.ToTable("SuplementTypes");

                    b.HasData(
                        new { Id = 1, Type = "Powder" },
                        new { Id = 2, Type = "Capsule" },
                        new { Id = 3, Type = "Softgels" },
                        new { Id = 4, Type = "Liquids" }
                    );
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Trainer", b =>
                {
                    b.Property<int?>("Id");

                    b.HasKey("Id");

                    b.ToTable("Trainers");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Workout", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Description");

                    b.Property<string>("Difficulty");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.Property<int?>("TrainerId");

                    b.Property<int>("WorkoutTypeId");

                    b.HasKey("Id");

                    b.HasIndex("TrainerId");

                    b.HasIndex("WorkoutTypeId");

                    b.ToTable("Workouts");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.WorkoutAdvice", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int?>("ClientId");

                    b.Property<DateTime>("CreatedAt");

                    b.Property<string>("Message");

                    b.Property<int?>("TrainerId");

                    b.HasKey("Id");

                    b.HasIndex("ClientId");

                    b.HasIndex("TrainerId");

                    b.ToTable("WorkoutAdvice");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.WorkoutSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<int>("DayOfTheWeek");

                    b.Property<string>("Description")
                        .IsRequired();

                    b.Property<TimeSpan>("TimeOfTheDay");

                    b.Property<int>("WorkoutId");

                    b.HasKey("Id");

                    b.HasIndex("WorkoutId");

                    b.ToTable("WorkoutSchedule");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.WorkoutType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("WorkoutTypes");

                    b.HasData(
                        new { Id = 1, Name = "Workout Type 1" },
                        new { Id = 2, Name = "Workout Type 2" },
                        new { Id = 3, Name = "Workout Type 3" }
                    );
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Client", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.AppUser", "AppUser")
                        .WithOne("Client")
                        .HasForeignKey("RS2_Seminarski.Database.Client", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Employee", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.AppUser", "AppUser")
                        .WithOne("Employee")
                        .HasForeignKey("RS2_Seminarski.Database.Employee", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.MembershipPayment", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Client", "Client")
                        .WithMany("MembershipPayments")
                        .HasForeignKey("ClientId");

                    b.HasOne("RS2_Seminarski.Database.Employee", "Employee")
                        .WithMany("MembershipPayments")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RS2_Seminarski.Database.MembershipType", "MembershipType")
                        .WithMany()
                        .HasForeignKey("MembershipTypeId");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Suplement", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.SuplementType", "SuplementType")
                        .WithMany()
                        .HasForeignKey("SuplementTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.SuplementPayment", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Client", "Client")
                        .WithMany("SuplementPayments")
                        .HasForeignKey("ClientId");

                    b.HasOne("RS2_Seminarski.Database.Employee", "Employee")
                        .WithMany("SuplementPayments")
                        .HasForeignKey("EmployeeId");

                    b.HasOne("RS2_Seminarski.Database.Suplement", "Suplement")
                        .WithMany("SuplementPayments")
                        .HasForeignKey("SuplementId");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.SuplementsRating", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Client", "Client")
                        .WithMany("SuplementsRatings")
                        .HasForeignKey("ClientId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("RS2_Seminarski.Database.Suplement", "Suplement")
                        .WithMany("SuplementsRatings")
                        .HasForeignKey("SuplementId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Trainer", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.AppUser", "AppUser")
                        .WithOne("Trainer")
                        .HasForeignKey("RS2_Seminarski.Database.Trainer", "Id")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.Workout", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Trainer", "Trainer")
                        .WithMany("Workouts")
                        .HasForeignKey("TrainerId");

                    b.HasOne("RS2_Seminarski.Database.WorkoutType", "WorkoutType")
                        .WithMany("Workouts")
                        .HasForeignKey("WorkoutTypeId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("RS2_Seminarski.Database.WorkoutAdvice", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Client", "Client")
                        .WithMany("WorkoutAdvices")
                        .HasForeignKey("ClientId");

                    b.HasOne("RS2_Seminarski.Database.Trainer", "Trainer")
                        .WithMany("WorkoutAdvices")
                        .HasForeignKey("TrainerId");
                });

            modelBuilder.Entity("RS2_Seminarski.Database.WorkoutSchedule", b =>
                {
                    b.HasOne("RS2_Seminarski.Database.Workout", "Workout")
                        .WithMany("WorkoutSchedules")
                        .HasForeignKey("WorkoutId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}