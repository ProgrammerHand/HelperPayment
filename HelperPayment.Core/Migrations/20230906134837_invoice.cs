using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace HelperPayment.Core.Migrations
{
    /// <inheritdoc />
    public partial class invoice : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "payments");

            migrationBuilder.CreateTable(
                name: "Invoices",
                schema: "payments",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Price = table.Column<double>(type: "float", nullable: false),
                    RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.Id);
                });

            //migrationBuilder.CreateTable(
            //    name: "Offers",
            //    columns: table => new
            //    {
            //        Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        InquiryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        CustomerId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
            //        Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
            //        Price = table.Column<double>(type: "float", nullable: true),
            //        PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: true),
            //        SolutionStorage = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RealisationStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDraft = table.Column<bool>(type: "bit", nullable: false),
            //        IsVerified = table.Column<bool>(type: "bit", nullable: false),
            //        Status = table.Column<int>(type: "int", nullable: false),
            //        ClientsReason = table.Column<string>(type: "nvarchar(max)", nullable: true),
            //        RowVersion = table.Column<byte[]>(type: "rowversion", rowVersion: true, nullable: false),
            //        CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        ModifiedAt = table.Column<DateTime>(type: "datetime2", nullable: false),
            //        IsDeleted = table.Column<bool>(type: "bit", nullable: false),
            //        DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true)
            //    },
            //    constraints: table =>
            //    {
            //        table.PrimaryKey("PK_Offers", x => x.Id);
            //    });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Invoices",
                schema: "payments");

            migrationBuilder.DropTable(
                name: "Offers");
        }
    }
}
