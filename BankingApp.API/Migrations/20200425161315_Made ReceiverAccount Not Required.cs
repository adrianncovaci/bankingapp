using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class MadeReceiverAccountNotRequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReceiverAccountId",
                table: "Transactions",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 162, DateTimeKind.Local).AddTicks(6750),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 526, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 147, DateTimeKind.Local).AddTicks(1447),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 510, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 131, DateTimeKind.Local).AddTicks(7540),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 495, DateTimeKind.Local).AddTicks(2217));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "ReceiverAccountId",
                table: "Transactions",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 526, DateTimeKind.Local).AddTicks(2966),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 162, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 510, DateTimeKind.Local).AddTicks(8184),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 147, DateTimeKind.Local).AddTicks(1447));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 495, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 19, 13, 15, 131, DateTimeKind.Local).AddTicks(7540));
        }
    }
}
