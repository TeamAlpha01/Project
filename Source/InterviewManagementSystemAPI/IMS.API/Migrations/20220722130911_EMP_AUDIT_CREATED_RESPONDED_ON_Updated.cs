using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Source.Migrations
{
    public partial class EMP_AUDIT_CREATED_RESPONDED_ON_Updated : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AdminRespondedOn",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "AccountCreatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8453), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8435), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8447), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8456) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8466), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8458), new DateTime(2022, 7, 26, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8463), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8467) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8470), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8468), new DateTime(2022, 7, 29, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8469), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8472) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8481), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8478), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8478), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8481) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8484), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8483), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8483), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8484) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8487), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8485), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8486), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8487) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8489), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8488), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8488), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8490) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8492), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8491), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8491), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8492) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8493), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8494), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8495) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8497), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8496), new DateTime(2022, 7, 26, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8496), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8498) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8501), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8499), new DateTime(2022, 7, 29, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8499), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8501) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8503), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8502), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8502), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8504) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8506), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8505), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8507) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8509), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8507), new DateTime(2022, 7, 26, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8508), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8509) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8513), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 7, 29, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8510), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8513) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8516), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8514), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8515), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8516) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8522), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8521), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8521), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8522) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8524), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8523), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8523), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8525) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8527), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8526), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8526), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8527) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8529), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8528), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8529), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8530) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8532), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8531), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8531), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8533) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8535), new DateTime(2022, 7, 25, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8533), new DateTime(2022, 7, 26, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8534), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8535) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8537), new DateTime(2022, 7, 28, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8536), new DateTime(2022, 7, 29, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8537), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8538) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8540), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8539), new DateTime(2022, 7, 23, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8539), new DateTime(2022, 7, 22, 18, 39, 10, 664, DateTimeKind.Local).AddTicks(8541) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "AdminRespondedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.AlterColumn<DateTime>(
                name: "AccountCreatedOn",
                table: "Employees",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2");

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 1,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8662), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8645), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8656), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8666) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 2,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8671), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8668), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8670), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8672) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 3,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8674), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8673), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8673), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8675) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 4,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8680), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8679), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8679), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8681) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 5,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8683), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8682), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8684) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 6,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8686), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8684), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8685), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8686) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 7,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8688), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8687), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8689) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 8,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8691), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8690), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8690), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8691) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 9,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8694), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8693), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8695) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 10,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8697), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8696), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8697) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 11,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8700), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8698), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8699), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8700) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 12,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8702), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8701), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8701), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8703) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 13,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8706), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8705), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8707) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 14,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8710), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8708), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8710) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 15,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8713), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8711), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8712), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8713) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 16,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8715), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8714), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8714), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8716) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 17,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8718), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8716), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8717), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8718) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 18,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8720), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8719), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8719), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8721) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 19,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8723), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8721), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8722), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8723) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 20,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8725), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8724), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8724), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8726) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 21,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8728), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8727), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8727), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8728) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 22,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8730), new DateTime(2022, 7, 25, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8729), new DateTime(2022, 7, 26, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8729), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8731) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 23,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8733), new DateTime(2022, 7, 28, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 7, 29, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8732), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8734) });

            migrationBuilder.UpdateData(
                table: "Drives",
                keyColumn: "DriveId",
                keyValue: 24,
                columns: new[] { "AddedOn", "FromDate", "ToDate", "UpdatedOn" },
                values: new object[] { new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8736), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8734), new DateTime(2022, 7, 23, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8735), new DateTime(2022, 7, 22, 18, 15, 34, 41, DateTimeKind.Local).AddTicks(8736) });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 1,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 2,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 3,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 4,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 5,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 6,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 7,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 8,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 9,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 10,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 11,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });

            migrationBuilder.UpdateData(
                table: "Employees",
                keyColumn: "EmployeeId",
                keyValue: 12,
                columns: new[] { "AccountCreatedOn", "AdminRespondedOn" },
                values: new object[] { null, null });
        }
    }
}
