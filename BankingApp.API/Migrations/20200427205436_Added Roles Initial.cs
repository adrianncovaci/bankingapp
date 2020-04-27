﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BankingApp.API.Migrations
{
    public partial class AddedRolesInitial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 226, DateTimeKind.Local).AddTicks(4283),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 577, DateTimeKind.Local).AddTicks(7101));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 195, DateTimeKind.Local).AddTicks(9954),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 548, DateTimeKind.Local).AddTicks(6804));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 183, DateTimeKind.Local).AddTicks(6758),
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldDefaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 534, DateTimeKind.Local).AddTicks(3600));

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 1, "f7cd8ad7-6b94-4efc-9cb9-a00bba016354", "Customer", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 2, "4fbfad1e-b250-4b06-83b2-584ee8b8d070", "LoanOfficer", null });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { 3, "fdb9aaeb-3d59-403f-afc3-e726b7635012", "Admin", null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateIssued",
                table: "Transactions",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 577, DateTimeKind.Local).AddTicks(7101),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 226, DateTimeKind.Local).AddTicks(4283));

            migrationBuilder.AlterColumn<DateTime>(
                name: "RegisteredDate",
                table: "Customers",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 548, DateTimeKind.Local).AddTicks(6804),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 195, DateTimeKind.Local).AddTicks(9954));

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateCreated",
                table: "BankAccounts",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(2020, 4, 27, 20, 40, 53, 534, DateTimeKind.Local).AddTicks(3600),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2020, 4, 27, 23, 54, 36, 183, DateTimeKind.Local).AddTicks(6758));
        }
    }
}
