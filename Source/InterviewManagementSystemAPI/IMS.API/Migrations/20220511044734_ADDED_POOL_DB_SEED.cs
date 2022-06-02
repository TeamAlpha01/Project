using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class ADDED_POOL_DB_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Pools",
                columns: new[] { "PoolId", "DepartmentId", "IsActive", "PoolName" },
                values: new object[,]
                {
                    { 1, 1, true, "Fresher .NET" },
                    { 2, 1, true, "SSE .NET" },
                    { 3, 2, true, "Fresher JAVA" },
                    { 4, 2, true, "SSE JAVA" },
                    { 5, 3, true, "Fresher ORACLE" },
                    { 6, 3, true, "SSE ORACLE" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Pools",
                keyColumn: "PoolId",
                keyValue: 6);
        }
    }
}
