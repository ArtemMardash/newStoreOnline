using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Billing.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddTotalPriceToBill : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "TotalPrice",
                table: "Bills",
                type: "double precision",
                nullable: false,
                defaultValue: 0.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalPrice",
                table: "Bills");
        }
    }
}
