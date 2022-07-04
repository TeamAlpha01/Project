using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class Updated_IsManagement : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsManagement",
                table: "Roles",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4208), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4192), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4202), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4211) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4215), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4213), new DateTime(2022, 7, 8, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4214), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4216) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4220), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4218), new DateTime(2022, 7, 11, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4219), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4221) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4224), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4222), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4223), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4225) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4229), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4227), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4227), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4230) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4234), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4231), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4232), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4235) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4238), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4236), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4237), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4239) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4242), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4240), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4241), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4243) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4246), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4244), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4245), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4247) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4282), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 7, 8, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4280), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4283) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4286), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4284), new DateTime(2022, 7, 11, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4285), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4287) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4291), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4289), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4290), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4292) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4295), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4293), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4294), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4296) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4299), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4297), new DateTime(2022, 7, 8, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4298), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4300) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4303), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4301), new DateTime(2022, 7, 11, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4302), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4304) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4308), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4306), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4306), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4308) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4312), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4310), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4310), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4313) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4317), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4315), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4315), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4318) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4321), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4319), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4319), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4321) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4324), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4323), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4323), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4325) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4328), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4326), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4327), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4329) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4332), new DateTime(2022, 7, 7, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4330), new DateTime(2022, 7, 8, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4331), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4333) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4336), new DateTime(2022, 7, 10, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4334), new DateTime(2022, 7, 11, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4335), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4337) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4340), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4338), new DateTime(2022, 7, 5, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4339), new DateTime(2022, 7, 4, 22, 37, 26, 918, DateTimeKind.Local).AddTicks(4341) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsManagement",
                table: "Roles");

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3473), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3457), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3468), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3476) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3479), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3477), new DateTime(2022, 7, 4, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3478), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3480) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3482), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3481), new DateTime(2022, 7, 7, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3481), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3483) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3485), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3483), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3484), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3485) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3487), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3486), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3486), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3488) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3490), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3488), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3489), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3490) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3492), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3491), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3491), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3493) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3494), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3493), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3494), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3495) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3501), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3500), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3500), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3501) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3504), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3502), new DateTime(2022, 7, 4, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3503), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3504) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3506), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3505), new DateTime(2022, 7, 7, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3505), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3507) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3509), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3508), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3508), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3509) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3511), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3510), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3511), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3512) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3514), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3513), new DateTime(2022, 7, 4, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3513), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3515) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3517), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3516), new DateTime(2022, 7, 7, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3516), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3518) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3520), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3518), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3519), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3520) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3522), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3521), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3521), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3523) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3528), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3527), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3527), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3529) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3531), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3529), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3530), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3531) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3533), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3532), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3532), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3534) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3536), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3534), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3535), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3536) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3538), new DateTime(2022, 7, 3, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3537), new DateTime(2022, 7, 4, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3537), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3539) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3541), new DateTime(2022, 7, 6, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3540), new DateTime(2022, 7, 7, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3540), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3541) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3543), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3542), new DateTime(2022, 7, 1, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3543), new DateTime(2022, 6, 30, 13, 57, 59, 241, DateTimeKind.Local).AddTicks(3544) });
        }
    }
}
