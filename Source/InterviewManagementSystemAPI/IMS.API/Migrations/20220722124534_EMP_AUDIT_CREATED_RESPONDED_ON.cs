using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class EMP_AUDIT_CREATED_RESPONDED_ON : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            
            migrationBuilder.AddColumn<DateTime>(
                name: "AccountCreatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AdminRespondedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8662), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8645), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8671), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8668), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8674), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8673), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8673), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8679), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8679), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8681) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8683), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8686), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8684), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8685), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8688), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8691), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8690), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8690), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8694), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8695) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8697), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8700), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8698), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8699), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8702), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8701), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8701), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8706), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8710), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8713), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8711), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8712), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8715), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8714), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8714), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8718), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8716), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8717), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8720), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8719), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8719), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8721) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8723), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8721), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8722), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8725), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8724), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8724), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8728), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8727), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8727), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8730), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8729), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8729), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8734) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8736), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8734), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8735), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8736) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AccountCreatedOn",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "AdminRespondedOn",
                table: "Employees");

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8728), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8712), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8722), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8735), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 7, 23, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8735) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8738), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8737), new DateTime(2022, 7, 26, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8737), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8739) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8741), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8739), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8740), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8741) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8743), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8742), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8743), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8744) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8746), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8745), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8745), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8747) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8749), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8748), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8748), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8749) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8752), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8750), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8751), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8752) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8754), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8753), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8753), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8755) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8757), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8756), new DateTime(2022, 7, 23, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8756), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8758) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8760), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8759), new DateTime(2022, 7, 26, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8759), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8760) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8763), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8761), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8762), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8763) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8765), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8764), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8764), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8766) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8768), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8767), new DateTime(2022, 7, 23, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8767), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8768) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8771), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8769), new DateTime(2022, 7, 26, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8770), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8771) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8774), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8772), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8772), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8775) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8777), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8776), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8776), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8777) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8779), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8778), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8778), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8780) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8782), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8781), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8782) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8785), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8783), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8784), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8785) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8787), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8786), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8786), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8788) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8790), new DateTime(2022, 7, 22, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8789), new DateTime(2022, 7, 23, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8789), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8790) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8793), new DateTime(2022, 7, 25, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8791), new DateTime(2022, 7, 26, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8792), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8793) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8795), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8794), new DateTime(2022, 7, 20, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8794), new DateTime(2022, 7, 19, 23, 10, 44, 791, DateTimeKind.Local).AddTicks(8796) });
        }
    }
}
