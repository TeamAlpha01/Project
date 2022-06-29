using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_SEEDING_DATA_DRIVES : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriveId", "AddedBy", "AddedOn", "CancelReason", "DepartmentId", "FromDate", "IsCancelled", "IsScheduled", "LocationId", "ModeId", "Name", "PoolId", "SlotTiming", "ToDate", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 1, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8840), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8824), false, true, 1, 2, "Freshers .Net Drive S", 1, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8834), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8842) },
                    { 2, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8844), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8843), false, false, 1, 2, "Freshers .Net Drive NS", 1, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8843), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8845) },
                    { 3, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8847), "Cancelled For Testing", 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8846), true, true, 1, 2, "Freshers .Net Drive C", 1, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8846), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8848) },
                    { 4, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8850), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8848), false, true, 9, 1, "SSE .Net Drive S", 2, 0.0, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8849), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8850) },
                    { 5, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8852), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8851), false, false, 9, 1, "SSE .Net Drive NS", 2, 0.0, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8851), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8853) },
                    { 6, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8855), "Cancelled For Testing", 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8853), true, true, 9, 1, "SSE .Net Drive C", 2, 0.0, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8854), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8855) },
                    { 7, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8857), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8856), false, true, 5, 1, "SLO .Net Drive S", 2, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8856), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8858) },
                    { 8, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8860), null, 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8858), false, false, 5, 1, "SLO .Net Drive NS", 2, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8859), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8860) },
                    { 9, 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8862), "Cancelled For Testing", 1, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8861), true, true, 5, 1, "SLO .Net Drive C", 2, 0.0, new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8861), 9, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8863) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9);
        }
    }
}
