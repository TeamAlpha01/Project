using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class FK_POOL_DRIVE_SATURDAY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Drives_PoolId",
                table: "Drives",
                column: "PoolId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Pools_PoolId",
                table: "Drives",
                column: "PoolId",
                principalTable: "Pools",
                principalColumn: "PoolId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Pools_PoolId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_PoolId",
                table: "Drives");
        }
    }
}
