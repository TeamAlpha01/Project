using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class Updated_EDR_with_Employee_FK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_EmployeeId",
                table: "EmployeeDriveResponse",
                column: "EmployeeId");

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeDriveResponse_Employees_EmployeeId",
                table: "EmployeeDriveResponse",
                column: "EmployeeId",
                principalTable: "Employees",
                principalColumn: "EmployeeId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeDriveResponse_Employees_EmployeeId",
                table: "EmployeeDriveResponse");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse");

            migrationBuilder.DropIndex(
                name: "IX_EmployeeDriveResponse_EmployeeId",
                table: "EmployeeDriveResponse");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse",
                column: "DriveId",
                unique: true);
        }
    }
}
