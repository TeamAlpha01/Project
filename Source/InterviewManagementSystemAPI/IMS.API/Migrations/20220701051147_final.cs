using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class final : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Locations",
                columns: table => new
                {
                    LocationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    LocationName = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Locations", x => x.LocationId);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.RoleId);
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
                        name: "FK_Pools_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction) ;
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeAceNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    EmailId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminAccepted = table.Column<bool>(type: "bit", nullable: false),
                    IsAdminResponded = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                    table.ForeignKey(
                        name: "FK_Employees_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Employees_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Drives",
                columns: table => new
                {
                    DriveId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: false),
                    FromDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ToDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PoolId = table.Column<int>(type: "int", nullable: false),
                    ModeId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    IsScheduled = table.Column<bool>(type: "bit", nullable: true),
                    IsCancelled = table.Column<bool>(type: "bit", nullable: true),
                    CancelReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AddedBy = table.Column<int>(type: "int", nullable: true),
                    AddedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UpdatedBy = table.Column<int>(type: "int", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SlotTiming = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Drives", x => x.DriveId);
                    table.ForeignKey(
                        name: "FK_Drives_Departments_DepartmentId",
                        column: x => x.DepartmentId,
                        principalTable: "Departments",
                        principalColumn: "DepartmentId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drives_Employees_AddedBy",
                        column: x => x.AddedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Drives_Employees_UpdatedBy",
                        column: x => x.UpdatedBy,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId");
                    table.ForeignKey(
                        name: "FK_Drives_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_Drives_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "PoolId",
                        onDelete: ReferentialAction.NoAction);
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
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_PoolMembers_Pools_PoolId",
                        column: x => x.PoolId,
                        principalTable: "Pools",
                        principalColumn: "PoolId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeAvailability",
                columns: table => new
                {
                    EmployeeAvailabilityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    InterviewDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    From = table.Column<DateTime>(type: "datetime2", nullable: false),
                    To = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsInterviewScheduled = table.Column<bool>(type: "bit", nullable: true),
                    IsInterviewCancelled = table.Column<bool>(type: "bit", nullable: true),
                    CancellationReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Comments = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeAvailability", x => x.EmployeeAvailabilityId);
                    table.ForeignKey(
                        name: "FK_EmployeeAvailability_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "DriveId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeAvailability_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeDriveResponse",
                columns: table => new
                {
                    ResponseId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DriveId = table.Column<int>(type: "int", nullable: false),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    ResponseType = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeDriveResponse", x => x.ResponseId);
                    table.ForeignKey(
                        name: "FK_EmployeeDriveResponse_Drives_DriveId",
                        column: x => x.DriveId,
                        principalTable: "Drives",
                        principalColumn: "DriveId",
                        onDelete: ReferentialAction.NoAction);
                    table.ForeignKey(
                        name: "FK_EmployeeDriveResponse_Employees_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employees",
                        principalColumn: "EmployeeId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "IsActive" },
                values: new object[,]
                {
                    { 1, ".NET", true },
                    { 2, "JAVA", true },
                    { 3, "ORACLE", true },
                    { 4, "LAMP", true },
                    { 5, "BFS", true },
                    { 6, "TAC", true },
                    { 7, "ADMIN", true }
                });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "LocationId", "IsActive", "LocationName" },
                values: new object[,]
                {
                    { 1, true, "Chennai" },
                    { 2, true, "Bangalore" },
                    { 3, true, "Mumbai" },
                    { 4, true, "Delhi" },
                    { 5, true, "Noida" },
                    { 6, true, "Hyderabad" },
                    { 7, true, "Kochin" },
                    { 8, true, "Coimbatore" },
                    { 9, true, "Not Applicable" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "RoleId", "IsActive", "RoleName" },
                values: new object[,]
                {
                    { 1, true, "Software Developer" },
                    { 2, true, "Senior Software Developer" },
                    { 3, true, "Project Manager" },
                    { 4, true, "Module Lead" },
                    { 5, true, "Technical Lead" },
                    { 6, true, "Software Architect" },
                    { 7, true, "Delivery Manager" },
                    { 8, true, "Service Line Owner" },
                    { 9, true, "TAC" },
                    { 10, true, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Pools",
                columns: new[] { "PoolId", "DepartmentId", "IsActive", "PoolName" },
                values: new object[,]
                {
                    { 1, 1, true, "Fresher .NET" },
                    { 2, 1, true, "SSE .NET" },
                    { 3, 1, true, "SLO .NET" },
                    { 4, 2, true, "Fresher JAVA" },
                    { 5, 2, true, "SSE JAVA" },
                    { 6, 2, true, "SLO JAVA" },
                    { 7, 3, true, "Fresher ORACLE" },
                    { 8, 3, true, "SSE ORACLE" },
                    { 9, 3, true, "SLO ORACLE" },
                    { 10, 4, true, "Fresher LAMP" },
                    { 11, 4, true, "SSE LAMP" },
                    { 12, 4, true, "SLO LAMP" },
                    { 13, 5, true, "Fresher BFS" },
                    { 14, 5, true, "SSE BFS" },
                    { 15, 5, true, "SLO BFS" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "DepartmentId", "IsActive", "ProjectName" },
                values: new object[,]
                {
                    { 1, 1, true, "Interview_Management_NET" },
                    { 2, 1, true, "Employee_Management_NET" },
                    { 3, 1, true, "Profile_Management_NET" },
                    { 4, 1, true, "Banking_NET" },
                    { 5, 2, true, "Interview_Management_JAVA" },
                    { 6, 2, true, "Employee_Management_JAVA" },
                    { 7, 2, true, "Profile_Management_JAVA" },
                    { 8, 2, true, "Banking_JAVA" },
                    { 9, 3, true, "Interview_Management_ORACLE" },
                    { 10, 3, true, "Employee_Management_ORACLE" },
                    { 11, 3, true, "Profile_Management_ORACLE" },
                    { 12, 3, true, "Banking_ORACLE" },
                    { 13, 4, true, "Interview_Management_LAMP" },
                    { 14, 4, true, "Employee_Management_LAMP" },
                    { 15, 4, true, "Profile_Management_LAMP" },
                    { 16, 4, true, "Banking_LAMP" },
                    { 17, 5, true, "Interview_Management_BFS" },
                    { 18, 5, true, "Employee_Management_BFS" },
                    { 19, 5, true, "Profile_Management_BFS" },
                    { 20, 5, true, "Banking_BFS" },
                    { 21, 6, true, "Not Applicable" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DepartmentId", "EmailId", "EmployeeAceNumber", "IsActive", "IsAdminAccepted", "IsAdminResponded", "Name", "Password", "ProjectId", "RoleId" },
                values: new object[,]
                {
                    { 1, 1, "prithvi.palani@aspiresys.com", "ACE0001", true, false, false, "Prithvi", "Pass@12345", 1, 1 },
                    { 2, 1, "vinoth.jayakumar@aspiresys.com", "ACE0002", true, false, false, "Vinoth", "Pass@12345", 1, 2 },
                    { 3, 1, "sheik.farid@aspiresys.com", "ACE0003", true, false, false, "Sheik", "Pass@12345", 1, 3 },
                    { 4, 2, "darshana@aspiresys.com", "ACE0004", true, false, false, "Darshana", "Pass@12345", 2, 1 },
                    { 5, 2, "aravind@aspiresys.com", "ACE0005", true, false, false, "Aravind", "Pass@12345", 2, 2 },
                    { 6, 2, "kumaresh@aspiresys.com", "ACE0006", true, false, false, "Kumaresh", "Pass@12345", 2, 3 },
                    { 7, 3, "gokul@aspiresys.com", "ACE0007", true, false, false, "Gokul", "Pass@12345", 3, 1 },
                    { 8, 3, "deepika@aspiresys.com", "ACE0008", true, false, false, "Deepika", "Pass@12345", 3, 2 },
                    { 9, 3, "remuki@aspiresys.com", "ACE0009", true, false, false, "Remuki", "Pass@12345", 3, 3 },
                    { 10, 6, "vishnu@aspiresys.com", "ACE0010", true, false, false, "Vishnu", "Pass@12345", 4, 9 },
                    { 11, 6, "sandhiya@aspiresys.com", "ACE0011", true, false, false, "Sandhiya", "Pass@12345", 4, 9 },
                    { 12, 7, "mani@aspiresys.com", "ACE0012", true, false, false, "Mani", "Pass@12345", 4, 10 }
                });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriveId", "AddedBy", "AddedOn", "CancelReason", "DepartmentId", "FromDate", "IsCancelled", "IsScheduled", "LocationId", "ModeId", "Name", "PoolId", "SlotTiming", "ToDate", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8675), null, 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8655), false, true, 1, 2, "Freshers .Net Drive T", 1, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8670), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8679) },
                    { 2, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8683), null, 1, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8681), false, true, 1, 2, "Freshers .Net Drive S", 1, 0.0, new DateTime(2022, 7, 5, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8681), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8683) },
                    { 3, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8685), null, 1, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8684), false, false, 1, 2, "Freshers .Net Drive U", 1, 0.0, new DateTime(2022, 7, 8, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8684), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8686) },
                    { 4, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8688), "Cancelled For Testing", 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8687), true, true, 1, 2, "Freshers .Net Drive C", 1, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8687), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8689) },
                    { 5, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8691), null, 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8689), false, true, 9, 1, "SSE .Net Drive T", 2, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8690), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8691) },
                    { 6, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8693), null, 1, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8692), false, true, 3, 2, "SSE .Net Drive S", 2, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8692), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8694) },
                    { 7, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8696), null, 1, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8695), false, false, 9, 1, "SSE .Net Drive U", 2, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8695), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8696) },
                    { 8, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8699), "Cancelled For Testing", 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8697), true, true, 9, 1, "SSE .Net Drive C", 2, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8698), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8699) },
                    { 9, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8701), null, 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8700), false, true, 9, 1, "SLO .Net Drive T", 2, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8700), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8702) },
                    { 10, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8704), null, 1, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8703), false, true, 5, 2, "SLO .Net Drive S", 2, 0.0, new DateTime(2022, 7, 5, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8703), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8705) },
                    { 11, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8707), null, 1, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8705), false, false, 5, 2, "SLO .Net Drive U", 2, 0.0, new DateTime(2022, 7, 8, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8706), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8707) },
                    { 12, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8709), "Cancelled For Testing", 1, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8708), true, true, 5, 1, "SLO .Net Drive C", 2, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8708), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8710) },
                    { 13, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8735), null, 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8733), false, true, 1, 2, "Freshers JAVA Drive T", 4, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8734), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8735) },
                    { 14, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8738), null, 2, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8736), false, true, 1, 2, "Freshers JAVA Drive S", 4, 0.0, new DateTime(2022, 7, 5, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8737), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8738) },
                    { 15, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8741), null, 2, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8739), false, false, 1, 2, "Freshers JAVA Drive U", 4, 0.0, new DateTime(2022, 7, 8, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8740), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8741) },
                    { 16, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8743), "Cancelled For Testing", 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8742), true, true, 1, 2, "Freshers JAVA Drive C", 4, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8742), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8744) },
                    { 17, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8746), null, 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8745), false, true, 9, 1, "SSE JAVA Drive T", 5, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8745), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8746) },
                    { 18, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8751), null, 2, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8747), false, true, 3, 2, "SSE JAVA Drive S", 5, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8748), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8751) },
                    { 19, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8754), null, 2, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8752), false, false, 9, 1, "SSE JAVA Drive U", 5, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8753), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8754) },
                    { 20, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8756), "Cancelled For Testing", 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8755), true, true, 9, 1, "SSE JAVA Drive C", 5, 0.0, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8755), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8757) },
                    { 21, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8759), null, 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8758), false, true, 9, 1, "SLO JAVA Drive T", 6, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8758), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8760) },
                    { 22, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8762), null, 2, new DateTime(2022, 7, 4, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8760), false, true, 5, 2, "SLO JAVA Drive S", 6, 0.0, new DateTime(2022, 7, 5, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8761), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8762) },
                    { 23, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8765), null, 2, new DateTime(2022, 7, 7, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8763), false, false, 5, 2, "SLO JAVA Drive U", 6, 0.0, new DateTime(2022, 7, 8, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8764), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8765) },
                    { 24, 10, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8767), "Cancelled For Testing", 2, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8766), true, true, 5, 1, "SLO JAVA Drive C", 6, 0.0, new DateTime(2022, 7, 2, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8766), 9, new DateTime(2022, 7, 1, 10, 41, 47, 626, DateTimeKind.Local).AddTicks(8768) }
                });

            migrationBuilder.InsertData(
                table: "PoolMembers",
                columns: new[] { "PoolMembersId", "EmployeeId", "IsActive", "PoolId" },
                values: new object[,]
                {
                    { 1, 1, true, 1 },
                    { 2, 2, true, 1 },
                    { 3, 2, true, 2 },
                    { 4, 3, true, 2 },
                    { 5, 4, true, 3 },
                    { 6, 5, true, 3 },
                    { 7, 5, true, 4 },
                    { 8, 6, true, 4 },
                    { 9, 7, true, 5 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Drives_AddedBy",
                table: "Drives",
                column: "AddedBy");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_DepartmentId",
                table: "Drives",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_LocationId",
                table: "Drives",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_PoolId",
                table: "Drives",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Drives_UpdatedBy",
                table: "Drives",
                column: "UpdatedBy");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAvailability_DriveId",
                table: "EmployeeAvailability",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeAvailability_EmployeeId",
                table: "EmployeeAvailability",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_DriveId",
                table: "EmployeeDriveResponse",
                column: "DriveId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeDriveResponse_EmployeeId",
                table: "EmployeeDriveResponse",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_DepartmentId",
                table: "Employees",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_ProjectId",
                table: "Employees",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Employees_RoleId",
                table: "Employees",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_EmployeeId",
                table: "PoolMembers",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_PoolMembers_PoolId",
                table: "PoolMembers",
                column: "PoolId");

            migrationBuilder.CreateIndex(
                name: "IX_Pools_DepartmentId",
                table: "Pools",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_DepartmentId",
                table: "Projects",
                column: "DepartmentId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EmployeeAvailability");

            migrationBuilder.DropTable(
                name: "EmployeeDriveResponse");

            migrationBuilder.DropTable(
                name: "PoolMembers");

            migrationBuilder.DropTable(
                name: "Drives");

            migrationBuilder.DropTable(
                name: "Employees");

            migrationBuilder.DropTable(
                name: "Locations");

            migrationBuilder.DropTable(
                name: "Pools");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
