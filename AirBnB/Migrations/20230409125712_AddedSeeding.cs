using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    public partial class AddedSeeding : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 5, true, null, "https://www.thespruce.com/thmb/iMt63n8NGCojUETr6-T8oj-5-ns=/1500x0/filters:no_upscale():max_bytes(150000):strip_icc()/PAinteriors-7-cafe9c2bd6be4823b9345e591e4f367f.jpg" },
                    { 7, false, 1, "https://theartofliving.nl/wp-content/uploads/2022/12/A1U-Maatwerk-Rob-Feenstra_12.jpg" },
                    { 8, false, 2, "https://www.drijvers-oisterwijk.nl/wp-content/uploads/2019/01/3201-Drijvers-Oisterwijk-interieur-restauratie-modern-landelijk-houten-spant-strak-licht-maatwerk-12.jpg" },
                    { 17, false, null, "https://st4.depositphotos.com/3429495/38405/i/600/depositphotos_384057762-stock-photo-cannes-france-may-karin-viard.jpg" }
                });

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Features",
                value: 52);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Features",
                value: 22);

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[,]
                {
                    { 3, "Kamer voor 2 personen", 4, 1, 3, 2, 20.99f, 1, "Kamer op een rustig gelegen plek dichtbij de stad", "Kamer in Almere" },
                    { 5, "Ruim opgezet hotel met uitzicht op zee", 36, 1, 4, 2, 120.5f, 5, "Geniet van luxe en comfort", "Zeezicht hotel" },
                    { 7, "Rustig gelegen appartement aan de rand van de stad", 28, 1, 0, 4, 90f, 3, "Ontsnap aan de drukte van de stad", "Appartement aan de rand van de stad" },
                    { 8, "Moderne villa met zwembad en uitzicht op de bergen", 28, 2, 5, 6, 350f, 4, "Luxe villa met veel privacy", "Villa met zwembad en bergzicht" },
                    { 9, "Gezellig appartement in historisch pand", 28, 2, 0, 3, 75f, 2, "Historische sfeer gecombineerd met modern comfort", "Appartement in historisch pand" }
                });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 6, false, 3, "https://images.squarespace-cdn.com/content/v1/5b097b4a4cde7ab1c2125706/90f9b45a-0c57-44b0-a566-53e4359a817e/CathieHong_Bookins_2.jpg?format=300w" },
                    { 9, true, 3, "https://images.squarespace-cdn.com/content/v1/5b097b4a4cde7ab1c2125706/90f9b45a-0c57-44b0-a566-53e4359a817e/CathieHong_Bookins_2.jpg?format=750w" },
                    { 11, true, 5, "https://www.specialhotels.nl/foto/foto_800_450/26073.jpg" },
                    { 13, true, 7, "https://media.indebuurt.nl/breda/2022/07/18140124/Miza-Bergen-op-Zoom.jpg" },
                    { 14, true, 8, "https://www.ruralcoast.com/galeria/inmuebles/chalet-indep-polop-1734-1.jpg" },
                    { 15, true, 9, "https://cloud.funda.nl/valentina_media/119/434/724_1080x720.jpg" },
                    { 19, false, 5, "https://interiorjunkie.com/wp-content/uploads/2020/10/hotel-chic-badkamer-2-685x1024.jpg" },
                    { 21, false, 7, "https://www.inrichting-huis.com/wp-content/afbeeldingen/interieur-appartement-hotelsfeer.jpg" },
                    { 22, false, 8, "https://www.ruralcoast.com/galeria/inmuebles/chalet-indep-polop-1734-4.jpg" },
                    { 23, false, 9, "https://img.vtwonen.nl/8a4eb93b559d0a56f0161a681c9fe9da5b2d52fd/5x-binnenkijken-in-een-monumentaal-pand" }
                });

            migrationBuilder.InsertData(
                table: "Landlords",
                columns: new[] { "Id", "Age", "AvatarId", "Email", "FirstName", "LastName", "Phone" },
                values: new object[] { 3, 45, 17, "karinjanssen@gmail.com", "Karin", "Janssen", "12345678" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[] { 4, "Gezellig chalet in de bossen", 6, 3, 2, 4, 80.99f, 2, "Verblijf midden in de natuur", "Chalet in de bossen" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[] { 6, "Gezellige studio in het centrum", 4, 3, 3, 2, 60.99f, 1, "Perfect voor een stedentrip", "Studio in Amsterdam" });

            migrationBuilder.InsertData(
                table: "Locations",
                columns: new[] { "Id", "Description", "Features", "LandlordId", "LocationType", "NumberOfGuests", "PricePerDay", "Rooms", "SubTitle", "Title" },
                values: new object[] { 10, "Comfortabel vakantiehuis met privétuin", 22, 3, 5, 8, 180f, 3, "Ideaal voor gezinnen of groepen vrienden", "Vakantiehuis met privétuin" });

            migrationBuilder.InsertData(
                table: "Images",
                columns: new[] { "Id", "IsCover", "LocationId", "Url" },
                values: new object[,]
                {
                    { 10, true, 4, "https://www.hoiveluwe.nl/custom/page/page_content_img/34780_original.jpg" },
                    { 12, true, 6, "https://040houserental.nl/wp-content/uploads/2022/01/DSC_0011_5_1.jpg" },
                    { 16, true, 10, "https://images.oyoroomscdn.com/uploads/hotel_image/100011873/medium/88812_lsr_2020052255142949050.jpg" },
                    { 18, false, 4, "https://dotnlgul4mfwg.cloudfront.net/wp-content/uploads/2018/04/13124619/boshuis_friesche_duin17__inline_staand_groot.jpg" },
                    { 20, false, 6, "https://images.homify.com/c_fill,f_auto,q_0,w_740/v1560373677/p/photo/image/3088926/P2_APRES.jpg" },
                    { 24, false, 10, "https://images.oyoroomscdn.com/uploads/hotel_image/100011873/medium/88812_lsr_202002084173854678.jpg" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 11);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 12);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 13);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 14);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 15);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 16);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 18);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 19);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 20);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 21);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 22);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 23);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 24);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 6);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 7);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DeleteData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 10);

            migrationBuilder.DeleteData(
                table: "Landlords",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Images",
                keyColumn: "Id",
                keyValue: 17);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 1,
                column: "Features",
                value: 32);

            migrationBuilder.UpdateData(
                table: "Locations",
                keyColumn: "Id",
                keyValue: 2,
                column: "Features",
                value: 2);
        }
    }
}
