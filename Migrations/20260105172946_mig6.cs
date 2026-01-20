using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TechnologySite.Migrations
{
    /// <inheritdoc />
    public partial class mig6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "InstagramUrl",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LinkedInUrl",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Location",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "LocationTitle",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "XUrl",
                table: "Footers",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InstagramUrl",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "LinkedInUrl",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "Location",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "LocationTitle",
                table: "Footers");

            migrationBuilder.DropColumn(
                name: "XUrl",
                table: "Footers");
        }
    }
}
