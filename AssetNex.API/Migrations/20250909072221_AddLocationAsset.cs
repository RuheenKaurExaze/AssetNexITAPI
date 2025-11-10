using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetNex.API.Migrations
{
    /// <inheritdoc />
    public partial class AddLocationAsset : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "Latitude",
                table: "Location",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "Longitude",
                table: "Location",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Location",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Latitude",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Longitude",
                table: "Location");

            migrationBuilder.DropColumn(
                name: "Name",
                table: "Location");
        }
    }
}
