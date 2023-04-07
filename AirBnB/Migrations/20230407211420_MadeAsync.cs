using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    public partial class MadeAsync : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "djoekeduijker@live.nl", "Djoeke", "Duijker" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "theoharissgouridis@gmail,com", "Theoharis", "Sgouridis" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://www.integervastgoed.nl/img/oasis-city-almere-1.png");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://assets-global.website-files.com/604668223c6f81ba87398bd4/60a2585a0441561aaca31be4_vooraanzicht%20woning.jpg");

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "keesvdspek@gmail.com", "Kees", "van der Spek" });

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "geertjan@gmail.com", "Geert-Jan", "Barends" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Features", "Title" },
                values: new object[] { "Huis in het centrum", 32, "Almere Apartement" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Features", "NumberOfGuests", "SubTitle", "Title" },
                values: new object[] { "Boerderij huisje, lekker afgelegen en dieren zijn toegestaan", 2, 10, "Prijzig, maar een echte landelijke ervaring.", "Woonboerderij" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Bilal.youssry@gmail.com", "Bilal", "Yousef" });

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "maxmetz8@gmail.com", "Max", "Metz" });

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 3,
                column: "Url",
                value: "https://www.chr-apartments.com/sites/default/files/styles/tile_image_cropped/public/video_thumbnails/Rwiy-8x8o5w.jpg?itok=X0MqiZeY");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 4,
                column: "Url",
                value: "https://www.mapofjoy.nl/wp-content/uploads/2022/11/kasteel-de-haar-mapofjoy.jpg");

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "herman@gmail.com", "Herman ", "Mol" });

            migrationBuilder.UpdateData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FirstName", "LastName" },
                values: new object[] { "Jaap@gmail.com", "Jaap", "Keizer" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Features", "Title" },
                values: new object[] { "Mooi huis gelegen in het centrum", 1, "BeeldhouwerKasteel" });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Features", "NumberOfGuests", "SubTitle", "Title" },
                values: new object[] { "Prachtig kasteel van Nederland", 1, 20, "Prijzig, maar een echte ervaring.", "Kasteel" });
        }
    }
}
