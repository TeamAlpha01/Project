using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class ADDED_POOL_MEMBERS_DB_SEED : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "PoolMembers",
                columns: new[] { "PoolMembersId", "EmployeeId", "IsActive", "PoolId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, true, 1 },
                    { 3, 2, true, 2 },
                    { 4, 3, true, 2 },
                    { 5, 4, true, 3 },
                    { 6, 5, true, 3 },
                    { 7, 5, true, 4 },
                    { 8, 6, true, 4 },
                    { 9, 7, true, 5 },
                    { 10, 8, true, 5 },
                    { 11, 8, true, 6 },
                    { 12, 9, true, 6 }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 12);
        }
    }
}
