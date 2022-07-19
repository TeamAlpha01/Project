using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class AUDIT1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Locations",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Locations",
                type: "datetime2",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Locations");

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4505), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4489), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4500), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4508) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4534), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4532), new DateTime(2022, 7, 22, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4532), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4535) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4537), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4536), new DateTime(2022, 7, 25, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4536), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4538) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4541), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4539), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4540), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4541) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4543), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4542), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4542), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4544) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4546), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4545), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4545), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4546) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4548), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4547), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4548), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4549) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4551), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4550), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4550), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4551) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4554), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4552), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4553), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4555) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4557), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4556), new DateTime(2022, 7, 22, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4556), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4558) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4560), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4558), new DateTime(2022, 7, 25, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4559), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4560) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4562), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4561), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4561), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4563) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4565), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4564), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4564), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4565) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4567), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4566), new DateTime(2022, 7, 22, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4567), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4568) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4570), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4569), new DateTime(2022, 7, 25, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4569), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4571) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4573), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4571), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4572), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4573) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4578), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4577), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4577), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4579) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4581), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4579), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4580), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4581) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4583), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4582), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4582), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4584) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4586), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4585), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4585), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4587) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4589), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4587), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4588), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4589) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4591), new DateTime(2022, 7, 21, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4590), new DateTime(2022, 7, 22, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4591), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4592) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4594), new DateTime(2022, 7, 24, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4593), new DateTime(2022, 7, 25, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4593), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4595) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4597), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4595), new DateTime(2022, 7, 19, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4596), new DateTime(2022, 7, 18, 12, 8, 19, 241, DateTimeKind.Local).AddTicks(4597) });
        }
    }
}
