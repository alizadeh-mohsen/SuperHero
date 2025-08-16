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
                    { "21adcf68-c554-4896-93da-4070697350d0", null, 4, "Thor", 0 },
                    { "22af5805-894a-4c4c-9154-80c71f82fdae", null, 1, "IronMan", 0 },
                    { "2c62e566-406f-4fc0-b617-0e873fa81502", null, 4, "Galactus", 1 },
                    { "302b7858-412f-4d31-8b95-9709d15620cc", null, 2, "The Hulk", 0 },
                    { "45de3945-7f14-4a9e-8861-330d6aae64c9", null, 1, "SpiderMan", 0 },
                    { "6c25b85c-2245-4df8-bc14-6364984c4940", null, 3, "SuperMan", 1 },
                    { "b271b120-7ed1-4edc-b905-e383f808365f", null, 0, "Batman", 1 },
                    { "b4ad628e-4d50-4d22-9883-8d41169f34fa", null, 3, "WonderWoman", 1 }
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
