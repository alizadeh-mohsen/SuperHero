using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperHero.API.Migrations
{
    /// <inheritdoc />
    public partial class init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Heroes",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Level = table.Column<int>(type: "int", nullable: false),
                    Universe = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Heroes", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Image", "Level", "Name", "Universe" },
                values: new object[,]
                {
                    { "1", "Supermanflying.png", 3, "SuperMan", 1 },
                    { "2", "Wonder_Woman_(2017_film)_poster.jpg", 3, "WonderWoman", 1 },
                    { "3", "Batman_Arkham_City_Game_Cover.jpg", 0, "Batman", 1 },
                    { "4", "Web_of_Spider-Man_Vol_1_129-1.png", 1, "SpiderMan", 0 },
                    { "5", "Hulk_(circa_2019).png", 2, "The Hulk", 0 },
                    { "6", "Thor_(film)_poster.jpg", 4, "Thor", 0 },
                    { "7", "Galactus_(2018).jpg", 4, "Galactus", 1 },
                    { "8", "Iron_Man_(circa_2018).png", 1, "IronMan", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Heroes");
        }
    }
}
