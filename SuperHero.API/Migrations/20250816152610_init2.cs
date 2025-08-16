using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SuperHero.API.Migrations
{
    /// <inheritdoc />
    public partial class init2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "21adcf68-c554-4896-93da-4070697350d0");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "22af5805-894a-4c4c-9154-80c71f82fdae");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "2c62e566-406f-4fc0-b617-0e873fa81502");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "302b7858-412f-4d31-8b95-9709d15620cc");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "45de3945-7f14-4a9e-8861-330d6aae64c9");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "6c25b85c-2245-4df8-bc14-6364984c4940");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "b271b120-7ed1-4edc-b905-e383f808365f");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "b4ad628e-4d50-4d22-9883-8d41169f34fa");

            migrationBuilder.InsertData(
                table: "Heroes",
                columns: new[] { "Id", "Image", "Level", "Name", "Universe" },
                values: new object[,]
                {
                    { "1", null, 3, "SuperMan", 1 },
                    { "2", null, 3, "WonderWoman", 1 },
                    { "3", null, 0, "Batman", 1 },
                    { "4", null, 1, "SpiderMan", 0 },
                    { "5", null, 2, "The Hulk", 0 },
                    { "6", null, 4, "Thor", 0 },
                    { "7", null, 4, "Galactus", 1 },
                    { "8", null, 1, "IronMan", 0 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "1");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "2");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "3");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "4");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "5");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "6");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "7");

            migrationBuilder.DeleteData(
                table: "Heroes",
                keyColumn: "Id",
                keyValue: "8");

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
    }
}
