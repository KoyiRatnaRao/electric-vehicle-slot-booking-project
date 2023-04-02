using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace EVProjectDup.Migrations
{
    /// <inheritdoc />
    public partial class AddStationToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.CreateTable(
                name: "stations",
                columns: table => new
                {
                    CSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CSEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfPorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagurl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_stations", x => x.CSId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
           

            migrationBuilder.CreateTable(
                name: "chargeStations",
                columns: table => new
                {
                    CSId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Adress = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSEmail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CSPhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NoOfPorts = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PinCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    imagurl = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_chargeStations", x => x.CSId);
                });
        }
    }
}
