using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class MadeReceiverAccountoptional : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 526, DateTimeKind.Local).AddTicks(2966),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 171, DateTimeKind.Local).AddTicks(7423));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 510, DateTimeKind.Local).AddTicks(8184),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 156, DateTimeKind.Local).AddTicks(4334));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 495, DateTimeKind.Local).AddTicks(2217),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 141, DateTimeKind.Local).AddTicks(6618));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 171, DateTimeKind.Local).AddTicks(7423),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 526, DateTimeKind.Local).AddTicks(2966));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 156, DateTimeKind.Local).AddTicks(4334),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 510, DateTimeKind.Local).AddTicks(8184));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 25, 18, 33, 39, 141, DateTimeKind.Local).AddTicks(6618),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 25, 18, 47, 38, 495, DateTimeKind.Local).AddTicks(2217));
        }
    }
}
