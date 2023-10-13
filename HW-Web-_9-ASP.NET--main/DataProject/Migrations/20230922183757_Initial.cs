using Microsoft.EntityFrameworkCore.Migrations;

namespace Kursova.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Colors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ColorName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Colors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Autos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Mark = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Model = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Price = table.Column<double>(type: "float", nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    ColorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Autos", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Autos_Colors_ColorId",
                        column: x => x.ColorId,
                        principalTable: "Colors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Colors",
                columns: new[] { "Id", "ColorName" },
                values: new object[,]
                {
                    { 1, "Blue" },
                    { 2, "Yellow" },
                    { 3, "Gray" },
                    { 4, "White" },
                    { 5, "Black" },
                    { 6, "Green" },
                    { 7, "Red" }
                });

            migrationBuilder.InsertData(
                table: "Autos",
                columns: new[] { "Id", "ColorId", "Mark", "Model", "Price", "Year" },
                values: new object[,]
                {
                    { 2, 1, "Mazda", "RX7", 2300.0, 1978 },
                    { 3, 2, "Toyota", "Land Cruiser", 7000.0, 2017 },
                    { 1, 3, "Audi", "80", 2500.0, 1978 },
                    { 5, 4, "BMW", "X5", 5000.0, 1999 },
                    { 4, 5, "ZAZ-1103", "Slavuta", 1500.0, 1988 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Autos_ColorId",
                table: "Autos",
                column: "ColorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Autos");

            migrationBuilder.DropTable(
                name: "Colors");
        }
    }
}
