using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class AUDIT : Migration
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

            migrationBuilder.AddColumn<int>(
                name: "AddedBy",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "AddedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedBy",
                table: "Departments",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdatedOn",
                table: "Departments",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3333), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3316), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3327), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3337) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3341), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3339), new DateTime(2022, 7, 22, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3340), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3342) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3414), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3412), new DateTime(2022, 7, 25, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3413), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3415) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3418), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3416), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3417), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3419) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3422), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3420), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3421), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3423) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3426), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3424), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3425), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3427) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3430), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3428), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3428), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3430) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3433), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3431), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3432), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3434) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3437), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3435), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3436), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3438) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3441), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3439), new DateTime(2022, 7, 22, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3440), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3442) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3446), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3444), new DateTime(2022, 7, 25, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3445), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3447) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3450), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3448), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3448), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3450) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3453), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3451), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3452), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3454) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3455), new DateTime(2022, 7, 22, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3456), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3458) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3461), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3459), new DateTime(2022, 7, 25, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3459), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3461) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3466), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3463), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3463), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3466) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3469), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3467), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3468), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3470) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3473), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3471), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3472), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3474) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3476), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3475), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3475), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3477) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3480), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3478), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3479), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3481) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3484), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3482), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3482), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3484) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3488), new DateTime(2022, 7, 21, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3486), new DateTime(2022, 7, 22, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3486), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3488) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3491), new DateTime(2022, 7, 24, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3490), new DateTime(2022, 7, 25, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3490), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3492) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3495), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3493), new DateTime(2022, 7, 19, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3494), new DateTime(2022, 7, 18, 9, 14, 47, 233, DateTimeKind.Local).AddTicks(3496) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AddedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "AddedOn",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedBy",
                table: "Departments");

            migrationBuilder.DropColumn(
                name: "UpdatedOn",
                table: "Departments");

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
        }
    }
}
