using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class first : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PoolId",
                table: "Employees",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Employees_PoolId",
                table: "Employees",
                column: "PoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Employees_Pools_PoolId",
                table: "Employees",
                column: "PoolId",
                principalTable: "Pools",
                principalColumn: "PoolId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Employees_Pools_PoolId",
                table: "Employees");

            migrationBuilder.DropIndex(
                name: "IX_Employees_PoolId",
                table: "Employees");

            migrationBuilder.DropColumn(
                name: "PoolId",
                table: "Employees");
        }
    }
}
