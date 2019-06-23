using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace RS2_Seminarski.Migrations
{
    public partial class Add_Suplement_Tables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.InsertData(
                table: "SuplementTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 1, "Powder" },
                    { 2, "Capsule" },
                    { 3, "Softgels" },
                    { 4, "Liquids" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Suplements_SuplementTypeId",
                table: "Suplements",
                column: "SuplementTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suplements");

            migrationBuilder.DropTable(
                name: "SuplementTypes");
        }
    }
}
