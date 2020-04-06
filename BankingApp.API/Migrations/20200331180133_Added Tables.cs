using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class AddedTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AccountStatus",
                columns: table => new
                {
                    AccountStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStatus", x => x.AccountStatusId);
                });

            migrationBuilder.CreateTable(
                name: "AccountTypes",
                columns: table => new
                {
                    AccountTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountTypes", x => x.AccountTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNP = table.Column<string>(maxLength: 13, nullable: true),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    CreditScore = table.Column<short>(nullable: false, defaultValue: (short)540),
                    State = table.Column<string>(nullable: false),
                    ZipCode = table.Column<string>(maxLength: 6, nullable: false),
                    Email = table.Column<string>(nullable: true),
                    RegisteredDate = table.Column<DateTime>(nullable: false),
                    DateHired = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "LoanOfficers",
                columns: table => new
                {
                    LoanOfficerId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(maxLength: 32, nullable: false),
                    LastName = table.Column<string>(maxLength: 32, nullable: false),
                    DateHired = table.Column<DateTime>(nullable: false),
                    EmailAddress = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanOfficers", x => x.LoanOfficerId);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequestStatus",
                columns: table => new
                {
                    LoanRequestStatusId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Status = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequestStatus", x => x.LoanRequestStatusId);
                });

            migrationBuilder.CreateTable(
                name: "LoanType",
                columns: table => new
                {
                    LoanTypeId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Type = table.Column<string>(maxLength: 128, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanType", x => x.LoanTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AccountNumber = table.Column<string>(maxLength: 13, nullable: false),
                    Balance = table.Column<decimal>(nullable: false),
                    MaintenanceFee = table.Column<decimal>(nullable: false),
                    InterestRate = table.Column<decimal>(nullable: false),
                    InitialDeposit = table.Column<decimal>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    LastDeposit = table.Column<DateTime>(nullable: true),
                    Period = table.Column<int>(nullable: true),
                    AccountStatusId = table.Column<int>(nullable: false),
                    AccountTypeId = table.Column<int>(nullable: false),
                    CustomerId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountStatus_AccountStatusId",
                        column: x => x.AccountStatusId,
                        principalTable: "AccountStatus",
                        principalColumn: "AccountStatusId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_AccountTypes_AccountTypeId",
                        column: x => x.AccountTypeId,
                        principalTable: "AccountTypes",
                        principalColumn: "AccountTypeId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Accounts_Customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "Customers",
                        principalColumn: "CustomerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Loan",
                columns: table => new
                {
                    LoanId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InterestRate = table.Column<decimal>(nullable: false),
                    Period = table.Column<int>(nullable: false),
                    LoanTypeId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Loan", x => x.LoanId);
                    table.ForeignKey(
                        name: "FK_Loan_LoanType_LoanTypeId",
                        column: x => x.LoanTypeId,
                        principalTable: "LoanType",
                        principalColumn: "LoanTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Transaction",
                columns: table => new
                {
                    TransactionId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    SenderAccountId = table.Column<int>(nullable: false),
                    ReceiverAccountId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transaction", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_Transaction_Accounts_ReceiverAccountId",
                        column: x => x.ReceiverAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Transaction_Accounts_SenderAccountId",
                        column: x => x.SenderAccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "LoanRequest",
                columns: table => new
                {
                    LoanRequestId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DateIssued = table.Column<DateTime>(nullable: false),
                    Comments = table.Column<string>(nullable: true),
                    ResponseDate = table.Column<DateTime>(nullable: true),
                    LoanRequestStatusId = table.Column<int>(nullable: false),
                    LoanOfficerId = table.Column<int>(nullable: false),
                    AccountId = table.Column<int>(nullable: false),
                    LoanId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoanRequest", x => x.LoanRequestId);
                    table.ForeignKey(
                        name: "FK_LoanRequest_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanRequest_Loan_LoanId",
                        column: x => x.LoanId,
                        principalTable: "Loan",
                        principalColumn: "LoanId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanRequest_LoanOfficers_LoanOfficerId",
                        column: x => x.LoanOfficerId,
                        principalTable: "LoanOfficers",
                        principalColumn: "LoanOfficerId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_LoanRequest_LoanRequestStatus_LoanRequestStatusId",
                        column: x => x.LoanRequestStatusId,
                        principalTable: "LoanRequestStatus",
                        principalColumn: "LoanRequestStatusId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "AccountStatus",
                columns: new[] { "AccountStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Active" },
                    { 2, "Frozen" }
                });

            migrationBuilder.InsertData(
                table: "AccountTypes",
                columns: new[] { "AccountTypeId", "Type" },
                values: new object[,]
                {
                    { 1, "Savings" },
                    { 2, "Checkings" },
                    { 3, "Retirement" }
                });

            migrationBuilder.InsertData(
                table: "LoanRequestStatus",
                columns: new[] { "LoanRequestStatusId", "Status" },
                values: new object[,]
                {
                    { 1, "Pending" },
                    { 2, "Accepted" },
                    { 3, "Declined" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountNumber",
                table: "Accounts",
                column: "AccountNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountStatusId",
                table: "Accounts",
                column: "AccountStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_AccountTypeId",
                table: "Accounts",
                column: "AccountTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_CustomerId",
                table: "Accounts",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_CNP",
                table: "Customers",
                column: "CNP",
                unique: true,
                filter: "[CNP] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Customers_Email",
                table: "Customers",
                column: "Email",
                unique: true,
                filter: "[Email] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Loan_LoanTypeId",
                table: "Loan",
                column: "LoanTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanOfficers_EmailAddress",
                table: "LoanOfficers",
                column: "EmailAddress",
                unique: true,
                filter: "[EmailAddress] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanOfficers_PhoneNumber",
                table: "LoanOfficers",
                column: "PhoneNumber",
                unique: true,
                filter: "[PhoneNumber] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequest_AccountId",
                table: "LoanRequest",
                column: "AccountId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequest_LoanId",
                table: "LoanRequest",
                column: "LoanId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequest_LoanOfficerId",
                table: "LoanRequest",
                column: "LoanOfficerId");

            migrationBuilder.CreateIndex(
                name: "IX_LoanRequest_LoanRequestStatusId",
                table: "LoanRequest",
                column: "LoanRequestStatusId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_ReceiverAccountId",
                table: "Transaction",
                column: "ReceiverAccountId");

            migrationBuilder.CreateIndex(
                name: "IX_Transaction_SenderAccountId",
                table: "Transaction",
                column: "SenderAccountId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoanRequest");

            migrationBuilder.DropTable(
                name: "Transaction");

            migrationBuilder.DropTable(
                name: "Loan");

            migrationBuilder.DropTable(
                name: "LoanOfficers");

            migrationBuilder.DropTable(
                name: "LoanRequestStatus");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "LoanType");

            migrationBuilder.DropTable(
                name: "AccountStatus");

            migrationBuilder.DropTable(
                name: "AccountTypes");

            migrationBuilder.DropTable(
                name: "Customers");
        }
    }
}
