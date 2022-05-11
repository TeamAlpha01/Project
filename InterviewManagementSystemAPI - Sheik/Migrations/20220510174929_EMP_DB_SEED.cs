using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class EMP_DB_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "EmailId", "EmployeeAceNumber", "IsActive", "IsAdminAccepted", "IsAdminResponded", "Name", "Password", "ProjectId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, "prithvi@gmail.com", "ACE0001", true, false, false, "Prithvi", "Pass@12345", 1, 1 },
                    { 2, 1, "vinoth@gmail.com", "ACE0002", true, false, false, "Vinoth", "Pass@12345", 1, 2 },
                    { 3, 1, "Sheik@gmail.com", "ACE0003", true, false, false, "Sheik", "Pass@12345", 1, 3 },
                    { 4, 2, "darshana@gmail.com", "ACE0004", true, false, false, "Darshana", "Pass@12345", 2, 1 },
                    { 5, 2, "aravind@gmail.com", "ACE0005", true, false, false, "Aravind", "Pass@12345", 2, 2 },
                    { 6, 2, "kumaresh@gmail.com", "ACE0006", true, false, false, "Kumaresh", "Pass@12345", 2, 3 },
                    { 7, 3, "gokul@gmail.com", "ACE0007", true, false, false, "Gokul", "Pass@12345", 3, 1 },
                    { 8, 3, "deepika@gmail.com", "ACE0008", true, false, false, "Deepika", "Pass@12345", 3, 2 },
                    { 9, 3, "remuki@gmail.com", "ACE0009", true, false, false, "Remuki", "Pass@12345", 3, 3 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9);
        }
    }
}
