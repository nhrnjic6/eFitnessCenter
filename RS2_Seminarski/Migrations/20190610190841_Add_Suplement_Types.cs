using Microsoft.EntityFrameworkCore.Migrations;

namespace RS2_Seminarski.Migrations
{
    public partial class Add_Suplement_Types : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "SuplementTypes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "SuplementTypes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "SuplementTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "SuplementTypes",
                keyColumn: "Id",
                keyValue: 4);
        }
    }
}
