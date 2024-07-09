using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class SecondCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Products_ProductId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "ProductId",
                table: "Photo",
                newName: "ProductPhotoId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_ProductId",
                table: "Photo",
                newName: "IX_Photo_ProductPhotoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Products_ProductPhotoId",
                table: "Photo",
                column: "ProductPhotoId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Photo_Products_ProductPhotoId",
                table: "Photo");

            migrationBuilder.RenameColumn(
                name: "ProductPhotoId",
                table: "Photo",
                newName: "ProductId");

            migrationBuilder.RenameIndex(
                name: "IX_Photo_ProductPhotoId",
                table: "Photo",
                newName: "IX_Photo_ProductId");

            migrationBuilder.AddForeignKey(
                name: "FK_Photo_Products_ProductId",
                table: "Photo",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
