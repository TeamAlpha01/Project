using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class PROJECT_DB_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[] { 1, 1, true, "IMS_NET" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[] { 2, 2, true, "IMS_JAVA" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[] { 3, 3, true, "IMS_ORACLE" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "ProjectId",
                keyValue: 3);
        }
    }
}
