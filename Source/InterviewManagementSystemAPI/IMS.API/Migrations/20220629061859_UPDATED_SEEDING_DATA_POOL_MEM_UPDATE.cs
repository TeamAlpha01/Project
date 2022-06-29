using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_SEEDING_DATA_POOL_MEM_UPDATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "PoolMembers",
                keyColumn: "PoolMembersId",
                keyValue: 12);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2061), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2046), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2056), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2064) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2089), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2087), new DateTime(2022, 7, 3, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2088), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2090) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2092), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2091), new DateTime(2022, 7, 6, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2091), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2093) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2095), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2094), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2094), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2096) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2098), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2097), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2097), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2098) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2100), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2099), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2099), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2101) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2103), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2102), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2104) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2106), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2105), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2105), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2106) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2109), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2107), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2108), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2109) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2111), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2110), new DateTime(2022, 7, 3, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2110), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2112) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2114), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2112), new DateTime(2022, 7, 6, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2113), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2114) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2116), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2115), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2117) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2119), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2118), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2118), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2120) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2122), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2120), new DateTime(2022, 7, 3, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2121), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2122) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2124), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 7, 6, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2123), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2125) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2127), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2125), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2126), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2127) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2129), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2128), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2128), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2130) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2131), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2130), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2131), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2132) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2134), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2133), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2133), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2134) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2136), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2135), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2136), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2137) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2140), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2138), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2139), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2140) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2142), new DateTime(2022, 7, 2, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2141), new DateTime(2022, 7, 3, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2141), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2143) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2145), new DateTime(2022, 7, 5, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2143), new DateTime(2022, 7, 6, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2144), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2145) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2147), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2146), new DateTime(2022, 6, 30, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2146), new DateTime(2022, 6, 29, 11, 48, 59, 370, DateTimeKind.Local).AddTicks(2148) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9787), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9771), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9781), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9791) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9794), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9792), new DateTime(2022, 7, 3, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9792), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9794) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9796), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9795), new DateTime(2022, 7, 6, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9796), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9797) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9799), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9798), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9798), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9800) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9802), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9800), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9801), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9802) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9804), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9803), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9803), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9805) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9807), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9806), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9807) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9809), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9808), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9808), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9810) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9812), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9811), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9811), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9812) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9815), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9813), new DateTime(2022, 7, 3, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9814), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9815) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9817), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9816), new DateTime(2022, 7, 6, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9816), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9818) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9820), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9819), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9819), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9821) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9823), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9821), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9822), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9823) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9825), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9824), new DateTime(2022, 7, 3, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9824), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9826) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9828), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9827), new DateTime(2022, 7, 6, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9827), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9828) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9831), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9829), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9830), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9831) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9833), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9832), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9832), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9834) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9836), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9835), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9835), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9836) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9838), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9837), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9837), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9839) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9841), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9840), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9840), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9841) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9843), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9842), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9843), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9844) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9846), new DateTime(2022, 7, 2, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9845), new DateTime(2022, 7, 3, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9845), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9847) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9849), new DateTime(2022, 7, 5, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9847), new DateTime(2022, 7, 6, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9848), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9849) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9856), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9855), new DateTime(2022, 6, 30, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9855), new DateTime(2022, 6, 29, 11, 44, 22, 650, DateTimeKind.Local).AddTicks(9857) });

            migrationBuilder.InsertData(
                table: "PoolMembers",
                columns: new[] { "PoolMembersId", "EmployeeId", "IsActive", "PoolId" },
                values: new object[,]
                {
                    { 10, 8, true, 5 },
                    { 11, 8, true, 6 },
                    { 12, 9, true, 6 }
                });
        }
    }
}
