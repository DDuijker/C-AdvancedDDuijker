using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AirBnB.Migrations
{
    /// <inheritdoc />
    public partial class ChangedID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Locations_Id",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_Id",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_Id",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_Id",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_Id",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Images_Id",
                table: "Images");

            migrationBuilder.AddColumn<int>(
                name: "CustomerId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Reservations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LandlordId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "LocationId",
                table: "Images",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations",
                column: "CustomerId");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_LandlordId",
                table: "Locations",
                column: "LandlordId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_LocationId",
                table: "Images",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Locations_LocationId",
                table: "Images",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations",
                column: "LandlordId",
                principalTable: "Landlords",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Images_Locations_LocationId",
                table: "Images");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Landlords_LandlordId",
                table: "Locations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Customers_CustomerId",
                table: "Reservations");

            migrationBuilder.DropForeignKey(
                name: "FK_Reservations_Locations_LocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_CustomerId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Reservations_LocationId",
                table: "Reservations");

            migrationBuilder.DropIndex(
                name: "IX_Locations_LandlordId",
                table: "Locations");

            migrationBuilder.DropIndex(
                name: "IX_Images_LocationId",
                table: "Images");

            migrationBuilder.DropColumn(
                name: "CustomerId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Reservations");

            migrationBuilder.DropColumn(
                name: "LandlordId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "LocationId",
                table: "Images");

            migrationBuilder.CreateIndex(
                name: "IX_Reservations_Id",
                table: "Reservations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Locations_Id",
                table: "Locations",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_Id",
                table: "Images",
                column: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Images_Locations_Id",
                table: "Images",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Landlords_Id",
                table: "Locations",
                column: "LocationId",
                principalTable: "Landlords",
                principalColumn: "LocationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Customers_Id",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Customers",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reservations_Locations_Id",
                table: "Reservations",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
