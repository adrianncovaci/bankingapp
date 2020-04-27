using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class RemovedBankAccountStatusTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankAccounts_BankAccountStatuses_AccountStatusId",
                table: "BankAccounts");

            migrationBuilder.DropTable(
                name: "BankAccountStatuses");

            migrationBuilder.DropIndex(
                name: "IX_BankAccounts_AccountStatusId",
                table: "BankAccounts");

            migrationBuilder.DropColumn(
                name: "AccountStatusId",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 107, DateTimeKind.Local).AddTicks(3054),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 308, DateTimeKind.Local).AddTicks(503));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 76, DateTimeKind.Local).AddTicks(1562),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 278, DateTimeKind.Local).AddTicks(2930));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 60, DateTimeKind.Local).AddTicks(2527),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 217, DateTimeKind.Local).AddTicks(1296));

            migrationBuilder.AddColumn<string>(
                name: "BankAccountStatus",
                table: "BankAccounts",
                nullable: false,
                defaultValue: "");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BankAccountStatus",
                table: "BankAccounts");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 308, DateTimeKind.Local).AddTicks(503),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 107, DateTimeKind.Local).AddTicks(3054));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 278, DateTimeKind.Local).AddTicks(2930),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 76, DateTimeKind.Local).AddTicks(1562));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 50, 48, 217, DateTimeKind.Local).AddTicks(1296),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 15, 59, 43, 60, DateTimeKind.Local).AddTicks(2527));

            migrationBuilder.AddColumn<int>(
                name: "AccountStatusId",
                table: "BankAccounts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "BankAccountStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankAccountStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "BankAccountStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Active" });

            migrationBuilder.InsertData(
                table: "BankAccountStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "Frozen" });

            migrationBuilder.CreateIndex(
                name: "IX_BankAccounts_AccountStatusId",
                table: "BankAccounts",
                column: "AccountStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankAccounts_BankAccountStatuses_AccountStatusId",
                table: "BankAccounts",
                column: "AccountStatusId",
                principalTable: "BankAccountStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
