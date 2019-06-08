using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS2_Seminarski.Migrations
{
    public partial class Add_Membership_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MembershipPayment");

            migrationBuilder.DropTable(
                name: "MembershipTypes");
        }
    }
}
