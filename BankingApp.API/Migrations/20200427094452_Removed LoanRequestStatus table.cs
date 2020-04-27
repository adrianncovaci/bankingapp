using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class RemovedLoanRequestStatustable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequests_LoanRequestStatuses_LoanRequestStatusId",
                table: "LoanRequests");

            migrationBuilder.DropTable(
                name: "LoanRequestStatuses");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequests_LoanRequestStatusId",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "LoanRequestStatusId",
                table: "LoanRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 249, DateTimeKind.Local).AddTicks(2376),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 66, DateTimeKind.Local).AddTicks(9827));

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "LoanRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 225, DateTimeKind.Local).AddTicks(1007),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 43, DateTimeKind.Local).AddTicks(2097));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 209, DateTimeKind.Local).AddTicks(3453),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 27, DateTimeKind.Local).AddTicks(9946));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Status",
                table: "LoanRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 66, DateTimeKind.Local).AddTicks(9827),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 249, DateTimeKind.Local).AddTicks(2376));

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestStatusId",
                table: "LoanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 43, DateTimeKind.Local).AddTicks(2097),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 225, DateTimeKind.Local).AddTicks(1007));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 29, 15, 27, DateTimeKind.Local).AddTicks(9946),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 12, 44, 52, 209, DateTimeKind.Local).AddTicks(3453));

            migrationBuilder.CreateTable(
                name: "LoanRequestStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestStatuses", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "LoanRequestStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 1, "Pending" });

            migrationBuilder.InsertData(
                table: "LoanRequestStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 2, "Accepted" });

            migrationBuilder.InsertData(
                table: "LoanRequestStatuses",
                columns: new[] { "Id", "Status" },
                values: new object[] { 3, "Declined" });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_LoanRequestStatusId",
                table: "LoanRequests",
                column: "LoanRequestStatusId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequests_LoanRequestStatuses_LoanRequestStatusId",
                table: "LoanRequests",
                column: "LoanRequestStatusId",
                principalTable: "LoanRequestStatuses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
