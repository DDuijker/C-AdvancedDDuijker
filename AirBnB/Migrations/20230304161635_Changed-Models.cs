using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    /// <inheritdoc />
    public partial class ChangedModels : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "State",
                table: "Locations",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "City",
                table: "Locations",
                newName: "SubTitle");

            migrationBuilder.RenameColumn(
                name: "Address",
                table: "Locations",
                newName: "Description");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Features",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationType",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "NumberOfGuests",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "PricePerDay",
                table: "Locations",
                type: "real",
                nullable: false,
                defaultValue: 0f);

            migrationBuilder.AddColumn<int>(
                name: "Rooms",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Features",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationType",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "NumberOfGuests",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "PricePerDay",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "Rooms",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Locations",
                newName: "State");

            migrationBuilder.RenameColumn(
                name: "SubTitle",
                table: "Locations",
                newName: "City");

            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Locations",
                newName: "Address");

            migrationBuilder.AlterColumn<int>(
                name: "LocationId",
                table: "Locations",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId");
        }
    }
}
