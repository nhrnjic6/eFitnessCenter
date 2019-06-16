using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS2_Seminarski.Migrations
{
    public partial class Add_Suplement_Payment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SuplementPayment");
        }
    }
}
