using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shahd_DataAccessL.Data.Migrations
{
    /// <inheritdoc />
    public partial class product3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Prodcts_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Prodcts_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodcts_Brands_BrandId",
                table: "Prodcts");

            migrationBuilder.DropForeignKey(
                name: "FK_Prodcts_Categoties_CategoryId",
                table: "Prodcts");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Prodcts",
                table: "Prodcts");

            migrationBuilder.RenameTable(
                name: "Prodcts",
                newName: "Products");

            migrationBuilder.RenameIndex(
                name: "IX_Prodcts_CategoryId",
                table: "Products",
                newName: "IX_Products_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Prodcts_BrandId",
                table: "Products",
                newName: "IX_Products_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Products",
                table: "Products",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_Categoties_CategoryId",
                table: "Products",
                column: "CategoryId",
                principalTable: "Categoties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Products_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Products_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Brands_BrandId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_Categoties_CategoryId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Products",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "Products",
                newName: "Prodcts");

            migrationBuilder.RenameIndex(
                name: "IX_Products_CategoryId",
                table: "Prodcts",
                newName: "IX_Prodcts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Products_BrandId",
                table: "Prodcts",
                newName: "IX_Prodcts_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Prodcts",
                table: "Prodcts",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Prodcts_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Prodcts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Prodcts_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Prodcts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcts_Brands_BrandId",
                table: "Prodcts",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Prodcts_Categoties_CategoryId",
                table: "Prodcts",
                column: "CategoryId",
                principalTable: "Categoties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
