using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class RemovedBankAccountLastDepositConfig : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 472, DateTimeKind.Local).AddTicks(5441),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 462, DateTimeKind.Local).AddTicks(6190));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 457, DateTimeKind.Local).AddTicks(5769),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 448, DateTimeKind.Local).AddTicks(2346));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 443, DateTimeKind.Local).AddTicks(1653),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 433, DateTimeKind.Local).AddTicks(7310));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 462, DateTimeKind.Local).AddTicks(6190),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 472, DateTimeKind.Local).AddTicks(5441));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 448, DateTimeKind.Local).AddTicks(2346),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 457, DateTimeKind.Local).AddTicks(5769));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 21, 0, 44, 33, 433, DateTimeKind.Local).AddTicks(7310),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 21, 1, 32, 6, 443, DateTimeKind.Local).AddTicks(1653));
        }
    }
}
