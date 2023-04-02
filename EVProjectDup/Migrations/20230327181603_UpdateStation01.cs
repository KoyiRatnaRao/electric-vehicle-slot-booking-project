using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVProjectDup.Migrations
{
    /// <inheritdoc />
    public partial class UpdateStation01 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Price",
                table: "stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "status",
                table: "stations",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Price",
                table: "stations");

            migrationBuilder.DropColumn(
                name: "status",
                table: "stations");
        }
    }
}
