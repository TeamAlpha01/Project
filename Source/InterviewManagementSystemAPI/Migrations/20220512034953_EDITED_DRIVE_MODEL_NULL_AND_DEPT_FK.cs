using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class EDITED_DRIVE_MODEL_NULL_AND_DEPT_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_AddedBy",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_UpdatedBy",
                table: "Drives");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Drives",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Drives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<bool>(
                name: "IsScheduled",
                table: "Drives",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<bool>(
                name: "IsCancelled",
                table: "Drives",
                type: "bit",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Drives",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy",
                table: "Drives",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "DepartmentId",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DepartmentId",
                table: "Drives",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Departments_DepartmentId",
                table: "Drives",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "DepartmentId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_AddedBy",
                table: "Drives",
                column: "AddedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_UpdatedBy",
                table: "Drives",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Departments_DepartmentId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_AddedBy",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_UpdatedBy",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_DepartmentId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Drives");

            migrationBuilder.AlterColumn<DateTime>(
                name: "UpdatedOn",
                table: "Drives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "UpdatedBy",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsScheduled",
                table: "Drives",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<bool>(
                name: "IsCancelled",
                table: "Drives",
                type: "bit",
                nullable: false,
                defaultValue: false,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AddedOn",
                table: "Drives",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "AddedBy",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_AddedBy",
                table: "Drives",
                column: "AddedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_UpdatedBy",
                table: "Drives",
                column: "UpdatedBy",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
