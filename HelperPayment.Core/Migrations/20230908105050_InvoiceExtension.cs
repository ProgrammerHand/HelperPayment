using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelperPayment.Core.Migrations
{
    /// <inheritdoc />
    public partial class InvoiceExtension : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "Proforma",
                schema: "payments",
                table: "Invoices",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Proforma",
                schema: "payments",
                table: "Invoices");
        }
    }
}
