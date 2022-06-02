using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_NOTMAPPED_EMP_AVAIL : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FromTime",
                table: "EmployeeAvailability");

            migrationBuilder.DropColumn(
                name: "ToTime",
                table: "EmployeeAvailability");

            migrationBuilder.AddColumn<DateTime>(
                name: "From",
                table: "EmployeeAvailability",
                type: "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "To",
                table: "EmployeeAvailability",
                type: "datetime2",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "From",
                table: "EmployeeAvailability");

            migrationBuilder.DropColumn(
                name: "To",
                table: "EmployeeAvailability");

            migrationBuilder.AddColumn<string>(
                name: "FromTime",
                table: "EmployeeAvailability",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "ToTime",
                table: "EmployeeAvailability",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
