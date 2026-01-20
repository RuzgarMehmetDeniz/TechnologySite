using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologySite.Migrations
{
    /// <inheritdoc />
    public partial class mig17 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ContactID",
                table: "Teams",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Contacts",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Teams_ContactID",
                table: "Teams",
                column: "ContactID");

            migrationBuilder.AddForeignKey(
                name: "FK_Teams_Contacts_ContactID",
                table: "Teams",
                column: "ContactID",
                principalTable: "Contacts",
                principalColumn: "ContactID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Teams_Contacts_ContactID",
                table: "Teams");

            migrationBuilder.DropIndex(
                name: "IX_Teams_ContactID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "ContactID",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Contacts");
        }
    }
}
