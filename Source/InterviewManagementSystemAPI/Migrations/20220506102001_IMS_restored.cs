using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class IMS_restored : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Pools",
                columns: table => new
                {
                    PoolId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PoolName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pools", x => x.PoolId);
                    table.ForeignKey(
                        name: "FK_Pools_Department_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PoolMembers",
                columns: table => new
                {
                    PoolMembersId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    PoolId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PoolMembers", x => x.PoolMembersId);
                    table.ForeignKey(
                        name: "FK_PoolMembers_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PoolMembers_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "PoolId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_EmployeeId",
                table: "PoolMembers",
                column: "EmployeeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_PoolId",
                table: "PoolMembers",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Pools_DepartmentId",
                table: "Pools",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PoolMembers");

            migrationBuilder.DropTable(
                name: "Pools");

            migrationBuilder.DropTable(
                name: "Department");
        }
    }
}
