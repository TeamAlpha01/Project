using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class FK_LOC_DRIVE_SATURDAY : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Drives_LocationId",
                table: "Drives",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drives_Locations_LocationId",
                table: "Drives",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drives_Locations_LocationId",
                table: "Drives");

            migrationBuilder.DropIndex(
                name: "IX_Drives_LocationId",
                table: "Drives");
        }
    }
}
