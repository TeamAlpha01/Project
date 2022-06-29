using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_SEEDING_DATA : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "DepartmentName",
                value: "LAMP");

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "IsActive" },
                values: new object[,]
                {
                    { 5, "BFS", true },
                    { 6, "TAC", true }
                });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "EmailId",
                value: "prithvi.palani@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "EmailId",
                value: "vinoth.jayakumar@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "EmailId",
                value: "sheik.farid@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "EmailId",
                value: "darshana@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "EmailId",
                value: "aravind@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                column: "EmailId",
                value: "kumaresh@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                column: "EmailId",
                value: "gokul@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                column: "EmailId",
                value: "deepika@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                column: "EmailId",
                value: "remuki@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                column: "EmailId",
                value: "vishnu@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                column: "EmailId",
                value: "sandhiya@aspiresys.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                column: "EmailId",
                value: "mani@aspiresys.com");

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "IsActive", "LocationName" },
                values: new object[,]
                {
                    { 6, true, "Hyderabad" },
                    { 7, true, "Kochin" },
                    { 8, true, "Coimbatore" },
                    { 9, true, "Not Applicable" }
                });

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 3,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 1, "SLO .NET" });

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 4,
                column: "PoolName",
                value: "Fresher JAVA");

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 5,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 2, "SSE JAVA" });

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 6,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 2, "SLO JAVA" });

            migrationBuilder.InsertData(
                table: "Pools",
                columns: new[] { "PoolId", "DepartmentId", "IsActive", "PoolName" },
                values: new object[,]
                {
                    { 7, 3, true, "Fresher ORACLE" },
                    { 8, 3, true, "SSE ORACLE" },
                    { 9, 3, true, "SLO ORACLE" },
                    { 10, 4, true, "Fresher LAMP" },
                    { 11, 4, true, "SSE LAMP" },
                    { 12, 4, true, "SLO LAMP" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "ProjectName",
                value: "Interview_Management_NET");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 1, "Employee_Management_NET" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 1, "Profile_Management_NET" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 1, "Banking_NET" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[,]
                {
                    { 5, 2, true, "Interview_Management_JAVA" },
                    { 6, 2, true, "Employee_Management_JAVA" },
                    { 7, 2, true, "Profile_Management_JAVA" },
                    { 8, 2, true, "Banking_JAVA" },
                    { 9, 3, true, "Interview_Management_ORACLE" },
                    { 10, 3, true, "Employee_Management_ORACLE" },
                    { 11, 3, true, "Profile_Management_ORACLE" },
                    { 12, 3, true, "Banking_ORACLE" },
                    { 13, 4, true, "Interview_Management_LAMP" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[,]
                {
                    { 14, 4, true, "Employee_Management_LAMP" },
                    { 15, 4, true, "Profile_Management_LAMP" },
                    { 16, 4, true, "Banking_LAMP" }
                });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 9,
                column: "RoleName",
                value: "TAC");

            migrationBuilder.InsertData(
                table: "Pools",
                columns: new[] { "PoolId", "DepartmentId", "IsActive", "PoolName" },
                values: new object[,]
                {
                    { 13, 5, true, "Fresher BFS" },
                    { 14, 5, true, "SSE BFS" },
                    { 15, 5, true, "SLO BFS" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[,]
                {
                    { 17, 5, true, "Interview_Management_BFS" },
                    { 18, 5, true, "Employee_Management_BFS" },
                    { 19, 5, true, "Profile_Management_BFS" },
                    { 20, 5, true, "Banking_BFS" },
                    { 21, 6, true, "Not Applicable" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 17);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 6);

            migrationBuilder.UpdateData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 4,
                column: "DepartmentName",
                value: "Not Applicable");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                column: "EmailId",
                value: "prithvi@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                column: "EmailId",
                value: "vinoth@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                column: "EmailId",
                value: "Sheik@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                column: "EmailId",
                value: "darshana@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                column: "EmailId",
                value: "aravind@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                column: "EmailId",
                value: "kumaresh@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                column: "EmailId",
                value: "gokul@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                column: "EmailId",
                value: "deepika@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                column: "EmailId",
                value: "remuki@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                column: "EmailId",
                value: "vishnu@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                column: "EmailId",
                value: "sandhiya@gmail.com");

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                column: "EmailId",
                value: "mani@gmail.com");

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 3,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 2, "Fresher JAVA" });

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 4,
                column: "PoolName",
                value: "SSE JAVA");

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 5,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 3, "Fresher ORACLE" });

            migrationBuilder.UpdateData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 6,
                columns: new[] { "DepartmentId", "PoolName" },
                values: new object[] { 3, "SSE ORACLE" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1,
                column: "ProjectName",
                value: "IMS_NET");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 2, "IMS_JAVA" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 3, "IMS_ORACLE" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 4,
                columns: new[] { "DepartmentId", "ProjectName" },
                values: new object[] { 4, "Not Applicable" });

            migrationBuilder.UpdateData(
                table: "Roles",
                keyColumn: "RoleId",
                keyValue: 9,
                column: "RoleName",
                value: "Talent");
        }
    }
}
