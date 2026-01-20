using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologySite.Migrations
{
    /// <inheritdoc />
    public partial class mig10 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "Footers",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Footers_CategoryID",
                table: "Footers",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_Footers_Categories_CategoryID",
                table: "Footers",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "CategoryID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Footers_Categories_CategoryID",
                table: "Footers");

            migrationBuilder.DropIndex(
                name: "IX_Footers_CategoryID",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "Footers");
        }
    }
}
