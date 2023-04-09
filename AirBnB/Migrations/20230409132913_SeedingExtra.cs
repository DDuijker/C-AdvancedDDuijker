using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    public partial class SeedingExtra : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "theoharissgouridis@gmail.com");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsCover",
                value: true);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[] { 11, "Een leuk uitje voor met zijn twee of een klein gezin", 4, 3, 1, 3, 30f, 3, "Leuke cottage", "Een stenen cottage" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[] { 25, true, 11, "https://www.standout-cabin-designs.com/images/small-stone-cottages1a.jpg" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[] { 26, false, 11, "https://usenaturalstone.org/wp-content/uploads/2016/03/Megy-Article-1.jpg" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 25);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 26);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.UpdateData(
                table: "Customers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Email",
                value: "theoharissgouridis@gmail,com");

            migrationBuilder.UpdateData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6,
                column: "IsCover",
                value: false);
        }
    }
}
