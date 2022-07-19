using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class AUDIT2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Roles",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Roles",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Projects",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Projects",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Pools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Pools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Pools",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Pools",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "PoolMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "PoolMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "PoolMembers",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "PoolMembers",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5012), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(4990), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5006), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5015) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5023), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5022), new DateTime(2022, 7, 22, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5022), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5024) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5026), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5025), new DateTime(2022, 7, 25, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5026), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5027) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5029), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5028), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5028), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5030) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5032), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5031), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5031), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5032) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5034), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5033), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5034), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5035) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5037), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5036), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5036), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5037) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5040), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5039), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5040), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5041) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5043), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5042), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5042), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5044) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5046), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5044), new DateTime(2022, 7, 22, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5045), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5046) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5049), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5047), new DateTime(2022, 7, 25, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5048), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5049) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5051), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5050), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5050), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5052) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5054), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5052), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5053), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5055) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5057), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5055), new DateTime(2022, 7, 22, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5056), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5057) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5059), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5058), new DateTime(2022, 7, 25, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5058), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5060) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5062), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5060), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5061), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5062) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5064), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5063), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5065) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5067), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5066), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5066), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5068) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5071), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5068), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5070), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5071) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5073), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5072), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5072), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5074) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5076), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5074), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5075), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5076) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5078), new DateTime(2022, 7, 21, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5077), new DateTime(2022, 7, 22, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5078), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5079) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5081), new DateTime(2022, 7, 24, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5080), new DateTime(2022, 7, 25, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5080), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5082) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5087), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5082), new DateTime(2022, 7, 19, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5083), new DateTime(2022, 7, 18, 15, 5, 50, 400, DateTimeKind.Local).AddTicks(5087) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Roles");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Projects");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Pools");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Pools");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Pools");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Pools");

            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "PoolMembers");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "PoolMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "PoolMembers");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "PoolMembers");

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7105), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7085), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7100), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7110) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7113), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7111), new DateTime(2022, 7, 22, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7112), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7114) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7116), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7115), new DateTime(2022, 7, 25, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7115), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7116) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7119), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7117), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7118), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7119) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7125), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7124), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7125), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7126) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7128), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7127), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7127), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7129) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7131), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7129), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7130), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7131) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7133), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7132), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7132), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7134) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7136), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7134), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7135), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7136) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7139), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7137), new DateTime(2022, 7, 22, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7138), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7139) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7142), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7141), new DateTime(2022, 7, 25, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7141), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7143) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7145), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7144), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7144), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7145) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7147), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7146), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7146), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7148) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7150), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7149), new DateTime(2022, 7, 22, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7149), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7150) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7152), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7151), new DateTime(2022, 7, 25, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7152), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7153) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7155), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7154), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7154), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7155) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7158), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7156), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7157), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7158) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7160), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7159), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7159), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7161) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7162), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7161), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7162), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7163) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7165), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7164), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7164), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7165) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7166), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7167), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7168) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7172), new DateTime(2022, 7, 21, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7169), new DateTime(2022, 7, 22, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7171), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7173) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7175), new DateTime(2022, 7, 24, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7174), new DateTime(2022, 7, 25, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7174), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7175) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7177), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7176), new DateTime(2022, 7, 19, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7177), new DateTime(2022, 7, 18, 14, 31, 32, 668, DateTimeKind.Local).AddTicks(7178) });
        }
    }
}
