using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_SEEDING_DATA_DRIVES_DATE_UPDATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5137), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5122), "Freshers .Net Drive T", new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5131), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5140) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5143), new DateTime(2022, 7, 2, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5141), true, "Freshers .Net Drive S", new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5142), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5144) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5146), null, new DateTime(2022, 7, 5, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5145), false, false, "Freshers .Net Drive U", new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5145), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5147) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "LocationId", "ModeId", "Name", "PoolId", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5149), "Cancelled For Testing", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5148), true, 1, 2, "Freshers .Net Drive C", 1, new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5148), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5150) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5152), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5150), true, "SSE .Net Drive T", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5151), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5152) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5154), null, new DateTime(2022, 7, 2, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5153), false, "SSE .Net Drive S", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5153), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5155) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "LocationId", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5157), new DateTime(2022, 7, 5, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5156), false, 9, "SSE .Net Drive U", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5156), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5157) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "IsScheduled", "LocationId", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5159), "Cancelled For Testing", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5158), true, true, 9, "SSE .Net Drive C", new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5158), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5160) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5162), null, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5161), false, "SLO .Net Drive T", new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5161), new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5162) });

            migrationBuilder.InsertData(
                table: "Drives",
                columns: new[] { "DriveId", "AddedBy", "AddedOn", "CancelReason", "DepartmentId", "FromDate", "IsCancelled", "IsScheduled", "LocationId", "ModeId", "Name", "PoolId", "SlotTiming", "ToDate", "UpdatedBy", "UpdatedOn" },
                values: new object[,]
                {
                    { 10, 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5168), null, 1, new DateTime(2022, 7, 2, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5167), false, true, 5, 1, "SLO .Net Drive S", 2, 0.0, new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5167), 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5169) },
                    { 11, 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5171), null, 1, new DateTime(2022, 7, 5, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5170), false, false, 5, 1, "SLO .Net Drive U", 2, 0.0, new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5170), 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5172) },
                    { 12, 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5174), "Cancelled For Testing", 1, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5172), true, true, 5, 1, "SLO .Net Drive C", 2, 0.0, new DateTime(2022, 6, 30, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5173), 9, new DateTime(2022, 6, 29, 10, 11, 27, 524, DateTimeKind.Local).AddTicks(5174) }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8840), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8824), "Freshers .Net Drive S", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8834), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8842) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8844), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8843), false, "Freshers .Net Drive NS", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8843), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8845) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8847), "Cancelled For Testing", new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8846), true, true, "Freshers .Net Drive C", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8846), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8848) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "LocationId", "ModeId", "Name", "PoolId", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8850), null, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8848), false, 9, 1, "SSE .Net Drive S", 2, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8849), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8850) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8852), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8851), false, "SSE .Net Drive NS", new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8851), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8853) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8855), "Cancelled For Testing", new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8853), true, "SSE .Net Drive C", new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8854), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8855) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "IsScheduled", "LocationId", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8857), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8856), true, 5, "SLO .Net Drive S", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8856), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8858) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "IsScheduled", "LocationId", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8860), null, new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8858), false, false, 5, "SLO .Net Drive NS", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8859), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8860) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "CancelReason", "FromDate", "IsCancelled", "Name", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8862), "Cancelled For Testing", new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8861), true, "SLO .Net Drive C", new DateTime(2022, 6, 30, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8861), new DateTime(2022, 6, 29, 9, 44, 25, 859, DateTimeKind.Local).AddTicks(8863) });
        }
    }
}
