using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class Changed_string_lenght : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "EmployeeAvailability",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationReason",
                table: "EmployeeAvailability",
                type: "nvarchar(40)",
                maxLength: 40,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9981), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9961), new DateTime(2022, 7, 16, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9973), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9985) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9990), new DateTime(2022, 7, 18, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9987), new DateTime(2022, 7, 19, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9988), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9991) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9994), new DateTime(2022, 7, 21, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9992), new DateTime(2022, 7, 22, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9993), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9995) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9998), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9996), new DateTime(2022, 7, 16, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9997), new DateTime(2022, 7, 15, 11, 9, 13, 261, DateTimeKind.Local).AddTicks(9999) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(2), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(1), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(3) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(7), new DateTime(2022, 7, 18, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(5), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(5), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(7) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(10), new DateTime(2022, 7, 21, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(9), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(9), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(11) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(14), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(12), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(13), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(15) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(18), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(16), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(17), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(19) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(22), new DateTime(2022, 7, 18, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(20), new DateTime(2022, 7, 19, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(21), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(23) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(27), new DateTime(2022, 7, 21, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(24), new DateTime(2022, 7, 22, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(25), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(28) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(31), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(29), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(29), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(31) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(35), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(33), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(33), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(36) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(39), new DateTime(2022, 7, 18, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(37), new DateTime(2022, 7, 19, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(37), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(40) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(43), new DateTime(2022, 7, 21, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(41), new DateTime(2022, 7, 22, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(41), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(44) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(47), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(45), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(45), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(50) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(54), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(52), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(52), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(54) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(57), new DateTime(2022, 7, 18, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(56), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(56), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(58) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(62), new DateTime(2022, 7, 21, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(60), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(61), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(63) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(66), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(65), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(65), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(67) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(70), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(68), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(69), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(71) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(74), new DateTime(2022, 7, 18, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(72), new DateTime(2022, 7, 19, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(73), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(75) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(78), new DateTime(2022, 7, 21, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(76), new DateTime(2022, 7, 22, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(76), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(78) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(116), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(113), new DateTime(2022, 7, 16, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(114), new DateTime(2022, 7, 15, 11, 9, 13, 262, DateTimeKind.Local).AddTicks(117) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9,
                column: "LocationName",
                value: "Online");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Comments",
                table: "EmployeeAvailability",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "CancellationReason",
                table: "EmployeeAvailability",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(40)",
                oldMaxLength: 40,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9252), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9236), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9245), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9258), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9256), new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9257), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9261), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9260), new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9260), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9263), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9263), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9271), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9270), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9270), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9273), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9272), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9273), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9276), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9275), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9275), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9277), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9281), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9280), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9280), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9284), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9282), new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9287), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9285), new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9286), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9287) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9289), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9288), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9288), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9292), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9291), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9291), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9294), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9293), new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9293), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9297), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9300), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9298), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9299), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9302), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9303), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9304), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9307), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9310), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9311), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9315), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9314), new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9314), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9318), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9316), new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9317), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9320), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9319), new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9319), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9321) });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "LocationId",
                keyValue: 9,
                column: "LocationName",
                value: "Not Applicable");
        }
    }
}
