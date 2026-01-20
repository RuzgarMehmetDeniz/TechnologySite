using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologySite.Migrations
{
    /// <inheritdoc />
    public partial class mig9 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AboutID",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Teams_AboutID",
                table: "Teams",
                column: "AboutID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Abouts_AboutID",
                table: "Teams",
                column: "AboutID",
                principalTable: "Abouts",
                principalColumn: "AboutID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Abouts_AboutID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_AboutID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "AboutID",
                table: "Teams");
        }
    }
}
