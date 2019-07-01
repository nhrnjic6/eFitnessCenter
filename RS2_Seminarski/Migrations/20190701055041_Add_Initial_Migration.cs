using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS2_Seminarski.Migrations
{
    public partial class Add_Initial_Migration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AppUsers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    FirstName = table.Column<string>(nullable: true),
                    LastName = table.Column<string>(nullable: true),
                    Email = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    HashedPassword = table.Column<string>(nullable: true),
                    Address = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    Status = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MembershipTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    MonthsValid = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Name = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "SuplementTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuplementTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WorkoutTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkoutTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Clients_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false),
                    Salary = table.Column<decimal>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employees_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Trainers",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainers", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Trainers_AppUsers_Id",
                        column: x => x.Id,
                        principalTable: "AppUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Suplements",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    SuplementTypeId = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Amount = table.Column<double>(nullable: false),
                    MessureUnit = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suplements", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Suplements_SuplementTypes_SuplementTypeId",
                        column: x => x.SuplementTypeId,
                        principalTable: "SuplementTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MembershipPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    MembershipTypeId = table.Column<int>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MembershipPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MembershipPayment_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipPayment_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_MembershipPayment_MembershipTypes_MembershipTypeId",
                        column: x => x.MembershipTypeId,
                        principalTable: "MembershipTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Workouts",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    CreatedAt = table.Column<DateTime>(nullable: false),
                    WorkoutTypeId = table.Column<int>(nullable: false),
                    TrainerId = table.Column<int>(nullable: true),
                    Description = table.Column<string>(nullable: true),
                    Duration = table.Column<int>(nullable: false),
                    Difficulty = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Workouts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Workouts_Trainers_TrainerId",
                        column: x => x.TrainerId,
                        principalTable: "Trainers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Workouts_WorkoutTypes_WorkoutTypeId",
                        column: x => x.WorkoutTypeId,
                        principalTable: "WorkoutTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SuplementPayment",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    ClientId = table.Column<int>(nullable: true),
                    EmployeeId = table.Column<int>(nullable: true),
                    SuplementId = table.Column<int>(nullable: true),
                    Amount = table.Column<int>(nullable: false),
                    CreatedAt = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SuplementPayment", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SuplementPayment_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuplementPayment_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_SuplementPayment_Suplements_SuplementId",
                        column: x => x.SuplementId,
                        principalTable: "Suplements",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "MembershipTypes",
                columns: new[] { "Id", "MonthsValid", "Name", "Price" },
                values: new object[,]
                {
                    { 1, 1, "Jedan Mjesec", 40.0 },
                    { 2, 2, "Dva Mjeseca", 70.0 },
                    { 3, 6, "Sest Mjeseci", 110.0 },
                    { 4, 12, "Godisnja Clanarina", 180.0 }
                });

            migrationBuilder.InsertData(
                table: "SuplementTypes",
                columns: new[] { "Id", "Type" },
                values: new object[,]
                {
                    { 1, "Powder" },
                    { 2, "Capsule" },
                    { 3, "Softgels" },
                    { 4, "Liquids" }
                });

            migrationBuilder.InsertData(
                table: "WorkoutTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Workout Type 1" },
                    { 2, "Workout Type 2" },
                    { 3, "Workout Type 3" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPayment_ClientId",
                table: "MembershipPayment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPayment_EmployeeId",
                table: "MembershipPayment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_MembershipPayment_MembershipTypeId",
                table: "MembershipPayment",
                column: "MembershipTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuplementPayment_ClientId",
                table: "SuplementPayment",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_SuplementPayment_EmployeeId",
                table: "SuplementPayment",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_SuplementPayment_SuplementId",
                table: "SuplementPayment",
                column: "SuplementId");

            migrationBuilder.CreateIndex(
                name: "IX_Suplements_SuplementTypeId",
                table: "Suplements",
                column: "SuplementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_TrainerId",
                table: "Workouts",
                column: "TrainerId");

            migrationBuilder.CreateIndex(
                name: "IX_Workouts_WorkoutTypeId",
                table: "Workouts",
                column: "WorkoutTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipPayment");

            migrationBuilder.DropTable(
                name: "SuplementPayment");

            migrationBuilder.DropTable(
                name: "Workouts");

            migrationBuilder.DropTable(
                name: "MembershipTypes");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Suplements");

            migrationBuilder.DropTable(
                name: "Trainers");

            migrationBuilder.DropTable(
                name: "WorkoutTypes");

            migrationBuilder.DropTable(
                name: "SuplementTypes");

            migrationBuilder.DropTable(
                name: "AppUsers");
        }
    }
}
