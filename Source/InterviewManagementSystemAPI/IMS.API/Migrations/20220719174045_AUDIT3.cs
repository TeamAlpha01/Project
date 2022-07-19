using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class AUDIT3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(25)",
                oldMaxLength: 25);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "LocationName",
                table: "Locations",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

            migrationBuilder.AlterColumn<string>(
                name: "DepartmentName",
                table: "Departments",
                type: "nvarchar(25)",
                maxLength: 25,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30);

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
