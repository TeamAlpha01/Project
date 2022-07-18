using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class Updated_seeding_18th_july : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAceNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drives",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: true,
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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "DepartmentId", "RoleId" },
                values: new object[] { 1, 7 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "EmailId", "Name" },
                values: new object[] { "admin@aspiresys.com", "Admin" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "ProjectName",
                table: "Projects",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Password",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmployeeAceNumber",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "EmailId",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drives",
                type: "nvarchar(30)",
                maxLength: 30,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(30)",
                oldMaxLength: 30,
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6496), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6478), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6490), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6500) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6504), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6501), new DateTime(2022, 7, 21, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6502), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6505) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6508), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6506), new DateTime(2022, 7, 24, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6507), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6509) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6514), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6512), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6512), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6515) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6518), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6516), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6516), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6518) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6521), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6519), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6520), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6522) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6553), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6551), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6552), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6554) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6557), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6556), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6556), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6558) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6561), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6559), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6560), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6562) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6566), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6563), new DateTime(2022, 7, 21, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6564), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6566) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6570), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6568), new DateTime(2022, 7, 24, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6568), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6570) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6573), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6571), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6572), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6574) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6577), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6575), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6576), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6578) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6582), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6579), new DateTime(2022, 7, 21, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6580), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6583) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6586), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6584), new DateTime(2022, 7, 24, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6584), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6586) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6589), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6587), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6588), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6590) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6593), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6591), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6592), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6593) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6596), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6595), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6595), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6597) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6600), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6598), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6599), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6601) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6603), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6602), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6602), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6604) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6607), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6605), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6606), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6608) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6611), new DateTime(2022, 7, 20, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6609), new DateTime(2022, 7, 21, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6610), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6611) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6614), new DateTime(2022, 7, 23, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6613), new DateTime(2022, 7, 24, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6613), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6615) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6618), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6616), new DateTime(2022, 7, 18, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6617), new DateTime(2022, 7, 17, 14, 13, 24, 763, DateTimeKind.Local).AddTicks(6619) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "DepartmentId", "RoleId" },
                values: new object[] { 6, 9 });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "EmailId", "Name" },
                values: new object[] { "mani@aspiresys.com", "Mani" });
        }
    }
}
