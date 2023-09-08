using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelperPayment.Core.Migrations
{
    /// <inheritdoc />
    public partial class furterInvoiceExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ClientsEmail",
                schema: "payments",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ClientsName",
                schema: "payments",
                table: "Invoices",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "OfferId",
                schema: "payments",
                table: "Invoices",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<int>(
                name: "Paid",
                schema: "payments",
                table: "Invoices",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "RealisationEnd",
                schema: "payments",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "RealisationStart",
                schema: "payments",
                table: "Invoices",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClientsEmail",
                schema: "payments",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "ClientsName",
                schema: "payments",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "OfferId",
                schema: "payments",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "Paid",
                schema: "payments",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RealisationEnd",
                schema: "payments",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "RealisationStart",
                schema: "payments",
                table: "Invoices");
        }
    }
}
