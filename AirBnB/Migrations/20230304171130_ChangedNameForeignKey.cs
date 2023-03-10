using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    /// <inheritdoc />
    public partial class ChangedNameForeignKey : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId1",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LandlordId1",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LandlordId1",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "LandlordForeignKeyId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordForeignKeyId",
                table: "Locations",
                column: "LandlordForeignKeyId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordForeignKeyId",
                table: "Locations",
                column: "LandlordForeignKeyId",
                principalTable: "Landlords",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordForeignKeyId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LandlordForeignKeyId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LandlordForeignKeyId",
                table: "Locations");

            migrationBuilder.AlterColumn<int>(
                name: "LandlordId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LandlordId1",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordId1",
                table: "Locations",
                column: "LandlordId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId1",
                table: "Locations",
                column: "LandlordId1",
                principalTable: "Landlords",
                principalColumn: "LocationId");
        }
    }
}
