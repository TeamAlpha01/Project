using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class Removed_PoolId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9252), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9236), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9245), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9255) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9258), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9256), 30.0, new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9257), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9259) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9261), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9260), 30.0, new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9260), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9262) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9264), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9263), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9263), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9264) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9271), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9270), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9270), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9271) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9273), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9272), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9273), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9274) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9276), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9275), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9275), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9276) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9277), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9278), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9279) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9281), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9280), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9280), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9282) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9284), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9282), 30.0, new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9283), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9284) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9287), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9285), 30.0, new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9286), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9287) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9289), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9288), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9288), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9290) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9292), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9291), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9291), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9292) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9294), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9293), 30.0, new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9293), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9295) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9297), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9296), 30.0, new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9296), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9298) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9300), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9298), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9299), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9300) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9302), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9301), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9301), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9303) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9305), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9303), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9304), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9305) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9307), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9306), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9306), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9308) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9310), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9309), 30.0, new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9309), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9310) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9311), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9312), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9313) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9315), new DateTime(2022, 7, 17, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9314), 30.0, new DateTime(2022, 7, 18, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9314), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9316) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9318), new DateTime(2022, 7, 20, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9316), 30.0, new DateTime(2022, 7, 21, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9317), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9318) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9320), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9319), 30.0, new DateTime(2022, 7, 15, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9319), new DateTime(2022, 7, 14, 21, 2, 26, 443, DateTimeKind.Local).AddTicks(9321) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2548), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2533), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2542), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2554) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2557), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2555), 0.0, new DateTime(2022, 7, 16, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2555), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2557) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2559), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2558), 0.0, new DateTime(2022, 7, 19, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2558), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2560) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2562), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2561), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2561), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2563) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2565), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2564), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2564), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2566) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2568), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2567), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2567), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2568) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2570), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2569), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2570), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2571) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2573), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2572), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2572), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2574) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2576), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2575), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2575), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2576) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2579), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2578), 0.0, new DateTime(2022, 7, 16, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2578), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2580) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2583), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2581), 0.0, new DateTime(2022, 7, 19, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2582), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2583) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2586), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2584), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2585), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2586) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2588), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2587), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2587), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2589) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2591), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2590), 0.0, new DateTime(2022, 7, 16, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2590), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2591) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2594), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2592), 0.0, new DateTime(2022, 7, 19, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2593), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2594) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2597), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2595), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2595), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2598) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2600), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2598), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2599), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2600) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2602), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2601), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2602), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2603) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2627), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2625), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2626), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2627) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2630), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2629), 0.0, new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2629), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2630) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2632), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2631), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2631), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2633) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2635), new DateTime(2022, 7, 15, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2633), 0.0, new DateTime(2022, 7, 16, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2634), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2635) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2637), new DateTime(2022, 7, 18, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2636), 0.0, new DateTime(2022, 7, 19, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2636), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2638) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "SlotTiming", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2640), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2639), 0.0, new DateTime(2022, 7, 13, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2639), new DateTime(2022, 7, 12, 16, 39, 23, 742, DateTimeKind.Local).AddTicks(2640) });
        }
    }
}
