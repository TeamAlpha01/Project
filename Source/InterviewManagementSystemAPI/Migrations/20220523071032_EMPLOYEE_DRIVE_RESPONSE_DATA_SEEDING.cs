using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class EMPLOYEE_DRIVE_RESPONSE_DATA_SEEDING : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "EmployeeDriveResponse",
                columns: new[] { "ResponseId", "DriveId", "EmployeeId", "ResponseType" },
                values: new object[,]
                {
                    { 1, 1, 1, 1 },
                    { 2, 2, 2, 1 },
                    { 3, 3, 3, 0 },
                    { 4, 4, 4, 1 },
                    { 5, 1, 5, 0 },
                    { 6, 2, 6, 1 },
                    { 7, 3, 7, 1 },
                    { 8, 5, 4, 1 },
                    { 9, 4, 5, 1 },
                    { 10, 5, 2, 1 },
                    { 11, 6, 1, 1 },
                    { 12, 7, 3, 0 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "EmployeeDriveResponse",
                keyColumn: "ResponseId",
                keyValue: 12);
        }
    }
}
