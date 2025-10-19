using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shahd_DataAccessL.Data.Migrations
{
    /// <inheritdoc />
    public partial class product22 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderItems_Product_ProductId",
                table: "OrderItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product");

            migrationBuilder.DropForeignKey(
                name: "FK_Product_Categoties_CategoryId",
                table: "Product");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Product",
                table: "Product");

            migrationBuilder.RenameTable(
                name: "Product",
                newName: "Prodcts");

            migrationBuilder.RenameIndex(
                name: "IX_Product_CategoryId",
                table: "Prodcts",
                newName: "IX_Prodcts_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Product_BrandId",
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "Product");

            migrationBuilder.RenameIndex(
                name: "IX_Prodcts_CategoryId",
                table: "Product",
                newName: "IX_Product_CategoryId");

            migrationBuilder.RenameIndex(
                name: "IX_Prodcts_BrandId",
                table: "Product",
                newName: "IX_Product_BrandId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Product",
                table: "Product",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Product_ProductId",
                table: "Carts",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderItems_Product_ProductId",
                table: "OrderItems",
                column: "ProductId",
                principalTable: "Product",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Brands_BrandId",
                table: "Product",
                column: "BrandId",
                principalTable: "Brands",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Product_Categoties_CategoryId",
                table: "Product",
                column: "CategoryId",
                principalTable: "Categoties",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
