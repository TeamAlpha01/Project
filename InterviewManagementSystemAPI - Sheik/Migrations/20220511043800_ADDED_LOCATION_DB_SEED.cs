using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class ADDED_LOCATION_DB_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "IsActive", "LocationName" },
                values: new object[,]
                {
                    { 1, true, "Chennai" },
                    { 2, true, "Bangalore" },
                    { 3, true, "Mumbai" },
                    { 4, true, "Delhi" },
                    { 5, true, "Noida" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 5);
        }
    }
}
