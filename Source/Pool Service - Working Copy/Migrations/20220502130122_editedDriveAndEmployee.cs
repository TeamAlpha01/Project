using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class editedDriveAndEmployee : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_AddedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_UpdatedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_AddedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_UpdatedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "AddedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.DropColumn(
                name: "UpdatedEmployeeEmployeeId",
                table: "Drives");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drives",
                type: "nvarchar(10)",
                maxLength: 10,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_AddedBy",
                table: "Drives",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_UpdatedBy",
                table: "Drives",
                column: "UpdatedBy");

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_AddedBy",
                table: "Drives");

            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Employees_UpdatedBy",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_AddedBy",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_UpdatedBy",
                table: "Drives");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Employees",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "Drives",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(10)",
                oldMaxLength: 10);

            migrationBuilder.AddColumn<int>(
                name: "AddedEmployeeEmployeeId",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpdatedEmployeeEmployeeId",
                table: "Drives",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Drives_AddedEmployeeEmployeeId",
                table: "Drives",
                column: "AddedEmployeeEmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_UpdatedEmployeeEmployeeId",
                table: "Drives",
                column: "UpdatedEmployeeEmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_AddedEmployeeEmployeeId",
                table: "Drives",
                column: "AddedEmployeeEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Employees_UpdatedEmployeeEmployeeId",
                table: "Drives",
                column: "UpdatedEmployeeEmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.NoAction);
        }
    }
}
