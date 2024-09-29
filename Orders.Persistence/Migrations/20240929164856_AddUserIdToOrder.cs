using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddUserIdToOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "PublicUserId",
                table: "Orders",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<Guid>(
                name: "SystemUserId",
                table: "Orders",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PublicUserId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "SystemUserId",
                table: "Orders");
        }
    }
}
