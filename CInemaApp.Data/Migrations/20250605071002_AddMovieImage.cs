using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CinemaApp.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddMovieImage : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("0a1139ed-aa71-43ef-8910-35328666c53d"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("112789ab-18f6-4040-8aeb-e7bbec962061"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("2e57e161-70b5-4f96-a0c7-a19dde6057fb"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("8bef01d5-aa76-4101-9cbf-e8fbfee247a5"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("008fbab2-6f98-4b4c-8bb4-d8562734d31d"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("5de38178-2beb-4d0f-b395-d9dfe17bdc65"));

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Movies",
                type: "nvarchar(2083)",
                maxLength: 2083,
                nullable: true,
                defaultValue: "~/images/no-image.jpg");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "ImageUrl", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("44da3a48-f5e3-4a35-99d1-3fd183324111"), "/images/cinema-ruse.jpg", "Ruse", "Cinema City" },
                    { new Guid("690b6ca2-0e51-4900-8eba-71e8e6465342"), "/images/cinema-varna.png", "Varna", "CinemaMax" },
                    { new Guid("6efd6307-df9c-40b8-8955-0585a8dd5e35"), "/images/cinema-sofia.jpeg", "Sofia", "Cinema" },
                    { new Guid("bdcaf3c4-562b-41f6-b4dc-c66633503162"), "/images/cinema-plovdiv.jpg", "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("9699479d-dcf9-4b70-b978-eb3b5f18dfda"), "In his fourth year at Hogwarts, Harry must reluctantly compete in an ancient wizard tournament after someone mysteriously selects his name, while the Dark Lord secretly conspires something sinister.", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of Fire" },
                    { new Guid("fe952d04-f97f-4341-8d35-b0907c1ca52f"), "Twilight is a 2008 American romantic fantasy film directed by Catherine Hardwicke from a screenplay by Melissa Rosenberg, based on the 2005 novel of the same name by Stephenie Meyer. It is the first installment in The Twilight Saga film series.", "Catherine Hardwicke", 121, "Fantasy", new DateTime(2008, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Twilight" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("44da3a48-f5e3-4a35-99d1-3fd183324111"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("690b6ca2-0e51-4900-8eba-71e8e6465342"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("6efd6307-df9c-40b8-8955-0585a8dd5e35"));

            migrationBuilder.DeleteData(
                table: "Cinemas",
                keyColumn: "Id",
                keyValue: new Guid("bdcaf3c4-562b-41f6-b4dc-c66633503162"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("9699479d-dcf9-4b70-b978-eb3b5f18dfda"));

            migrationBuilder.DeleteData(
                table: "Movies",
                keyColumn: "Id",
                keyValue: new Guid("fe952d04-f97f-4341-8d35-b0907c1ca52f"));

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Movies");

            migrationBuilder.InsertData(
                table: "Cinemas",
                columns: new[] { "Id", "ImageUrl", "Location", "Name" },
                values: new object[,]
                {
                    { new Guid("0a1139ed-aa71-43ef-8910-35328666c53d"), "/images/cinema-ruse.jpg", "Ruse", "Cinema City" },
                    { new Guid("112789ab-18f6-4040-8aeb-e7bbec962061"), "/images/cinema-sofia.jpeg", "Sofia", "Cinema" },
                    { new Guid("2e57e161-70b5-4f96-a0c7-a19dde6057fb"), "/images/cinema-varna.png", "Varna", "CinemaMax" },
                    { new Guid("8bef01d5-aa76-4101-9cbf-e8fbfee247a5"), "/images/cinema-plovdiv.jpg", "Plovdiv", "Cinema City" }
                });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "Description", "Director", "Duration", "Genre", "ReleaseDate", "Title" },
                values: new object[,]
                {
                    { new Guid("008fbab2-6f98-4b4c-8bb4-d8562734d31d"), "In his fourth year at Hogwarts, Harry must reluctantly compete in an ancient wizard tournament after someone mysteriously selects his name, while the Dark Lord secretly conspires something sinister.", "Mike Newel", 157, "Fantasy", new DateTime(2005, 11, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Harry Potter and the Goblet of Fire" },
                    { new Guid("5de38178-2beb-4d0f-b395-d9dfe17bdc65"), "Twilight is a 2008 American romantic fantasy film directed by Catherine Hardwicke from a screenplay by Melissa Rosenberg, based on the 2005 novel of the same name by Stephenie Meyer. It is the first installment in The Twilight Saga film series.", "Catherine Hardwicke", 121, "Fantasy", new DateTime(2008, 10, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Twilight" }
                });
        }
    }
}
