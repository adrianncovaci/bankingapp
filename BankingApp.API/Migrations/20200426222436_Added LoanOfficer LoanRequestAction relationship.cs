using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class AddedLoanOfficerLoanRequestActionrelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequests_LoanOfficers_LoanOfficerId",
                table: "LoanRequests");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequests_LoanOfficerId",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "LoanOfficerId",
                table: "LoanRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 439, DateTimeKind.Local).AddTicks(5797),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 288, DateTimeKind.Local).AddTicks(9762));

            migrationBuilder.AddColumn<int>(
                name: "LoanRequestActionId",
                table: "LoanRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 415, DateTimeKind.Local).AddTicks(1146),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 268, DateTimeKind.Local).AddTicks(8702));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 399, DateTimeKind.Local).AddTicks(9209),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 253, DateTimeKind.Local).AddTicks(9644));

            migrationBuilder.CreateTable(
                name: "LoanRequestActions",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateAction = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestActions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "LoanOfficerLoanRequestActions",
                columns: table => new
                {
                    LoanOfficerId = table.Column<int>(nullable: false),
                    LoanRequestActionId = table.Column<int>(nullable: false)
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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LoanRequests_LoanRequestActions_LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.DropTable(
                name: "LoanOfficerLoanRequestActions");

            migrationBuilder.DropTable(
                name: "LoanRequestActions");

            migrationBuilder.DropIndex(
                name: "IX_LoanRequests_LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.DropColumn(
                name: "LoanRequestActionId",
                table: "LoanRequests");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 288, DateTimeKind.Local).AddTicks(9762),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 439, DateTimeKind.Local).AddTicks(5797));

            migrationBuilder.AddColumn<int>(
                name: "LoanOfficerId",
                table: "LoanRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 268, DateTimeKind.Local).AddTicks(8702),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 415, DateTimeKind.Local).AddTicks(1146));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 0, 34, 0, 253, DateTimeKind.Local).AddTicks(9644),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 1, 24, 35, 399, DateTimeKind.Local).AddTicks(9209));

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequests_LoanOfficerId",
                table: "LoanRequests",
                column: "LoanOfficerId");

            migrationBuilder.AddForeignKey(
                name: "FK_LoanRequests_LoanOfficers_LoanOfficerId",
                table: "LoanRequests",
                column: "LoanOfficerId",
                principalTable: "LoanOfficers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
