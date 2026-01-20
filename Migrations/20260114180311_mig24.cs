using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologySite.Migrations
{
    /// <inheritdoc />
    public partial class mig24 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopSlider_Products_ProductID",
                table: "TopSlider");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopSlider",
                table: "TopSlider");

            migrationBuilder.RenameTable(
                name: "TopSlider",
                newName: "TopSliders");

            migrationBuilder.RenameIndex(
                name: "IX_TopSlider_ProductID",
                table: "TopSliders",
                newName: "IX_TopSliders_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopSliders",
                table: "TopSliders",
                column: "TopSliderID");

            migrationBuilder.AddForeignKey(
                name: "FK_TopSliders_Products_ProductID",
                table: "TopSliders",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TopSliders_Products_ProductID",
                table: "TopSliders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TopSliders",
                table: "TopSliders");

            migrationBuilder.RenameTable(
                name: "TopSliders",
                newName: "TopSlider");

            migrationBuilder.RenameIndex(
                name: "IX_TopSliders_ProductID",
                table: "TopSlider",
                newName: "IX_TopSlider_ProductID");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TopSlider",
                table: "TopSlider",
                column: "TopSliderID");

            migrationBuilder.AddForeignKey(
                name: "FK_TopSlider_Products_ProductID",
                table: "TopSlider",
                column: "ProductID",
                principalTable: "Products",
                principalColumn: "ProductID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
