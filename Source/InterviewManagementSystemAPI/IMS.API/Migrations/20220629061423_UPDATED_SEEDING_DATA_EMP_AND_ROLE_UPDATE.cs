using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class UPDATED_SEEDING_DATA_EMP_AND_ROLE_UPDATE : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName", "IsActive" },
                values: new object[] { 7, "ADMIN", true });

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

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                column: "DepartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                column: "DepartmentId",
                value: 6);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                column: "DepartmentId",
                value: 7);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 7);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7393), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7375), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7387), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7395) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7398), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7396), new DateTime(2022, 7, 3, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7397), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7399) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7401), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 7, 6, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7400), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7401) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7404), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7402), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7403), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7404) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7406), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7405), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7406), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7407) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7409), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7408), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7408), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7410) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7412), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7410), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7411), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7412) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7414), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7413), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7413), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7415) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7417), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7416), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7416), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7418) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7420), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7418), new DateTime(2022, 7, 3, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7419), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7420) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7422), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7421), new DateTime(2022, 7, 6, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7421), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7423) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7425), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7424), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7424), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7425) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7428), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7426), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7427), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7428) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7430), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7429), new DateTime(2022, 7, 3, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7429), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7431) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7433), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7431), new DateTime(2022, 7, 6, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7432), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7433) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7438), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7437), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7437), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7439) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7441), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7440), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7440), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7441) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7443), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7442), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7442), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7444) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7446), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7444), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7445), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7446) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7448), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7447), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7447), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7449) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7451), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7449), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7450), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7451) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7453), new DateTime(2022, 7, 2, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7452), new DateTime(2022, 7, 3, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7452), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7454) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7456), new DateTime(2022, 7, 5, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7454), new DateTime(2022, 7, 6, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7455), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7456) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7458), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7457), new DateTime(2022, 6, 30, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7457), new DateTime(2022, 6, 29, 11, 38, 25, 112, DateTimeKind.Local).AddTicks(7459) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                column: "DepartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                column: "DepartmentId",
                value: 4);

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                column: "DepartmentId",
                value: 4);
        }
    }
}
