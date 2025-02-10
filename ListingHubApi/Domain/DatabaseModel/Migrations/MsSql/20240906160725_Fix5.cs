using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Fix5 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos");

            migrationBuilder.DropIndex(
                name: "IX_ListingDescriptions_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "SubNeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_ListingDescriptions_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions",
                column: "ListingId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "SubNeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "SubNeighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_ListingDescriptions_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions");

            migrationBuilder.AlterColumn<int>(
                name: "ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_ListingDescriptions_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions",
                column: "ListingId");

            migrationBuilder.AddForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
