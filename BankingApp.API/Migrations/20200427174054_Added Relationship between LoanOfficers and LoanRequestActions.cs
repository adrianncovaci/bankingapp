using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class AddedRelationshipbetweenLoanOfficersandLoanRequestActions : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequests_LoanRequestActions_LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.DropTable(
                name: "LoanOfficerLoanRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequests_LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 577, DateTimeKind.Local).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 110, DateTimeKind.Local).AddTicks(3652));

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "Loans",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AddColumn<string>(
                name: "Action",
                table: "LoanRequestActions",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "LoanOfficerId",
                table: "LoanRequestActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestId",
                table: "LoanRequestActions",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 548, DateTimeKind.Local).AddTicks(6804),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 84, DateTimeKind.Local).AddTicks(1554));

            migrationBuilder.AlterColumn<decimal>(
                name: "InitialInterestRate",
                table: "BankAccountTypes",
                nullable: true,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)",
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "BankAccounts",
                nullable: false,
                oldClrType: typeof(decimal),
                oldType: "decimal(18,4)");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 534, DateTimeKind.Local).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 70, DateTimeKind.Local).AddTicks(1575));

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestActions_LoanOfficerId",
                table: "LoanRequestActions",
                column: "LoanOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequestActions_LoanRequestId",
                table: "LoanRequestActions",
                column: "LoanRequestId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequestActions_LoanOfficers_LoanOfficerId",
                table: "LoanRequestActions",
                column: "LoanOfficerId",
                principalTable: "LoanOfficers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequestActions_LoanRequests_LoanRequestId",
                table: "LoanRequestActions",
                column: "LoanRequestId",
                principalTable: "LoanRequests",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequestActions_LoanOfficers_LoanOfficerId",
                table: "LoanRequestActions");

            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequestActions_LoanRequests_LoanRequestId",
                table: "LoanRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequestActions_LoanOfficerId",
                table: "LoanRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequestActions_LoanRequestId",
                table: "LoanRequestActions");

            migrationBuilder.DropColumn(
                name: "Action",
                table: "LoanRequestActions");

            migrationBuilder.DropColumn(
                name: "LoanOfficerId",
                table: "LoanRequestActions");

            migrationBuilder.DropColumn(
                name: "LoanRequestId",
                table: "LoanRequestActions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 110, DateTimeKind.Local).AddTicks(3652),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 577, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "Loans",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestActionId",
                table: "LoanRequests",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 84, DateTimeKind.Local).AddTicks(1554),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 548, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.AlterColumn<decimal>(
                name: "InitialInterestRate",
                table: "BankAccountTypes",
                type: "decimal(18,4)",
                nullable: true,
                oldClrType: typeof(decimal),
                oldNullable: true);

            migrationBuilder.AlterColumn<decimal>(
                name: "InterestRate",
                table: "BankAccounts",
                type: "decimal(18,4)",
                nullable: false,
                oldClrType: typeof(decimal));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 17, 34, 54, 70, DateTimeKind.Local).AddTicks(1575),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 534, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.CreateTable(
                name: "LoanOfficerLoanRequestActions",
                columns: table => new
                {
                    LoanOfficerId = table.Column<int>(type: "int", nullable: false),
                    LoanRequestActionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOfficerLoanRequestActions", x => new { x.LoanOfficerId, x.LoanRequestActionId });
                    table.ForeignKey(
                        name: "FK_LoanOfficerLoanRequestActions_LoanOfficers_LoanOfficerId",
                        column: x => x.LoanOfficerId,
                        principalTable: "LoanOfficers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LoanOfficerLoanRequestActions_LoanRequestActions_LoanRequestActionId",
                        column: x => x.LoanRequestActionId,
                        principalTable: "LoanRequestActions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_LoanRequestActionId",
                table: "LoanRequests",
                column: "LoanRequestActionId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanOfficerLoanRequestActions_LoanRequestActionId",
                table: "LoanOfficerLoanRequestActions",
                column: "LoanRequestActionId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequests_LoanRequestActions_LoanRequestActionId",
                table: "LoanRequests",
                column: "LoanRequestActionId",
                principalTable: "LoanRequestActions",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
