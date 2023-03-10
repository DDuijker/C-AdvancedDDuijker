using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    /// <inheritdoc />
    public partial class OnModelCreating : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Landlords_LandlordId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Images_LandlordId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Images");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(200)",
                oldMaxLength: 200);

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(500)",
                oldMaxLength: 500);

            migrationBuilder.AddColumn<int>(
                name: "LandlordId1",
                table: "Locations",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Landlords",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(100)",
                oldMaxLength: 100);

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordId1",
                table: "Locations",
                column: "LandlordId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId1",
                table: "Locations",
                column: "LandlordId1",
                principalTable: "Landlords",
                principalColumn: "LocationId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId1",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LandlordId1",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LandlordId1",
                table: "Locations");

            migrationBuilder.AlterColumn<string>(
                name: "Title",
                table: "Locations",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "SubTitle",
                table: "Locations",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Description",
                table: "Locations",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Phone",
                table: "Landlords",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "LastName",
                table: "Landlords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "FirstName",
                table: "Landlords",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<string>(
                name: "Email",
                table: "Landlords",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Images_LandlordId",
                table: "Images",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Landlords_LandlordId",
                table: "Images",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
