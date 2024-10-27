using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Orders.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class AddedSystemId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_ProductsPublicId",
                table: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_ProductsPublicId",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "ProductsPublicId",
                table: "OrdersProducts");

            migrationBuilder.AddColumn<Guid>(
                name: "SystemId",
                table: "Products",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "ProductsSystemId",
                table: "OrdersProducts",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "SystemId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrdersSystemId", "ProductsSystemId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductsSystemId",
                table: "OrdersProducts",
                column: "ProductsSystemId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductsSystemId",
                table: "OrdersProducts",
                column: "ProductsSystemId",
                principalTable: "Products",
                principalColumn: "SystemId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrdersProducts_Products_ProductsSystemId",
                table: "OrdersProducts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts");

            migrationBuilder.DropIndex(
                name: "IX_OrdersProducts_ProductsSystemId",
                table: "OrdersProducts");

            migrationBuilder.DropColumn(
                name: "SystemId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ProductsSystemId",
                table: "OrdersProducts");

            migrationBuilder.AddColumn<string>(
                name: "ProductsPublicId",
                table: "OrdersProducts",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "PublicId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrdersProducts",
                table: "OrdersProducts",
                columns: new[] { "OrdersSystemId", "ProductsPublicId" });

            migrationBuilder.CreateIndex(
                name: "IX_OrdersProducts_ProductsPublicId",
                table: "OrdersProducts",
                column: "ProductsPublicId");

            migrationBuilder.AddForeignKey(
                name: "FK_OrdersProducts_Products_ProductsPublicId",
                table: "OrdersProducts",
                column: "ProductsPublicId",
                principalTable: "Products",
                principalColumn: "PublicId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
