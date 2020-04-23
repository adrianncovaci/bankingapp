using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class ModifiedBankAccountTypesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 462, DateTimeKind.Local).AddTicks(6190),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 501, DateTimeKind.Local).AddTicks(8675));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 448, DateTimeKind.Local).AddTicks(2346),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 487, DateTimeKind.Local).AddTicks(2872));

            migrationBuilder.AddColumn<decimal>(
                name: "InitialInterestRate",
                table: "BankAccountTypes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaintenanceFee",
                table: "BankAccountTypes",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 433, DateTimeKind.Local).AddTicks(7310),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 472, DateTimeKind.Local).AddTicks(7463));

            migrationBuilder.UpdateData(
                table: "BankAccountTypes",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "InitialInterestRate", "MaintenanceFee" },
                values: new object[] { 0.03m, 10m });

            migrationBuilder.UpdateData(
                table: "BankAccountTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "MaintenanceFee",
                value: 10m);

            migrationBuilder.UpdateData(
                table: "BankAccountTypes",
                keyColumn: "Id",
                keyValue: 3,
                column: "InitialInterestRate",
                value: 0.04m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InitialInterestRate",
                table: "BankAccountTypes");

            migrationBuilder.DropColumn(
                name: "MaintenanceFee",
                table: "BankAccountTypes");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 501, DateTimeKind.Local).AddTicks(8675),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 462, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 487, DateTimeKind.Local).AddTicks(2872),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 448, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 20, 20, 4, 59, 472, DateTimeKind.Local).AddTicks(7463),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 433, DateTimeKind.Local).AddTicks(7310));
        }
    }
}
