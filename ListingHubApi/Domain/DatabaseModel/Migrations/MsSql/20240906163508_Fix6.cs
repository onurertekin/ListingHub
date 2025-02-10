using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DatabaseModel.Migrations.MsSql
{
    /// <inheritdoc />
    public partial class Fix6 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "ListingHub",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                schema: "ListingHub",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDescriptions_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFields_Fields_FieldId",
                schema: "ListingHub",
                table: "ListingFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFields_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Categories_CategoryId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                schema: "ListingHub",
                table: "Neighbourhoods");

            migrationBuilder.CreateIndex(
                name: "IX_SubNeighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "SubNeighbourhoods",
                column: "NeighbourhoodId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_CityId",
                schema: "ListingHub",
                table: "Listings",
                column: "CityId");

            migrationBuilder.CreateIndex(
                name: "IX_Listings_DistrictId",
                schema: "ListingHub",
                table: "Listings",
                column: "DistrictId");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "ListingHub",
                table: "Categories",
                column: "ParentCategoryId",
                principalSchema: "ListingHub",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                schema: "ListingHub",
                table: "Districts",
                column: "CityId",
                principalSchema: "ListingHub",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDescriptions_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFields_Fields_FieldId",
                schema: "ListingHub",
                table: "ListingFields",
                column: "FieldId",
                principalSchema: "ListingHub",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFields_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingFields",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Categories_CategoryId",
                schema: "ListingHub",
                table: "Listings",
                column: "CategoryId",
                principalSchema: "ListingHub",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Cities_CityId",
                schema: "ListingHub",
                table: "Listings",
                column: "CityId",
                principalSchema: "ListingHub",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Districts_DistrictId",
                schema: "ListingHub",
                table: "Listings",
                column: "DistrictId",
                principalSchema: "ListingHub",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "NeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "Neighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "SubNeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "SubNeighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                schema: "ListingHub",
                table: "Neighbourhoods",
                column: "DistrictId",
                principalSchema: "ListingHub",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_SubNeighbourhoods_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "SubNeighbourhoods",
                column: "NeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "Neighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "ListingHub",
                table: "Categories");

            migrationBuilder.DropForeignKey(
                name: "FK_Districts_Cities_CityId",
                schema: "ListingHub",
                table: "Districts");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingDescriptions_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFields_Fields_FieldId",
                schema: "ListingHub",
                table: "ListingFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingFields_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingFields");

            migrationBuilder.DropForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Categories_CategoryId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Cities_CityId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Districts_DistrictId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                schema: "ListingHub",
                table: "Neighbourhoods");

            migrationBuilder.DropForeignKey(
                name: "FK_SubNeighbourhoods_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "SubNeighbourhoods");

            migrationBuilder.DropIndex(
                name: "IX_SubNeighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "SubNeighbourhoods");

            migrationBuilder.DropIndex(
                name: "IX_Listings_CityId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.DropIndex(
                name: "IX_Listings_DistrictId",
                schema: "ListingHub",
                table: "Listings");

            migrationBuilder.AddForeignKey(
                name: "FK_Categories_Categories_ParentCategoryId",
                schema: "ListingHub",
                table: "Categories",
                column: "ParentCategoryId",
                principalSchema: "ListingHub",
                principalTable: "Categories",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Districts_Cities_CityId",
                schema: "ListingHub",
                table: "Districts",
                column: "CityId",
                principalSchema: "ListingHub",
                principalTable: "Cities",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingDescriptions_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingDescriptions",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFields_Fields_FieldId",
                schema: "ListingHub",
                table: "ListingFields",
                column: "FieldId",
                principalSchema: "ListingHub",
                principalTable: "Fields",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingFields_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingFields",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ListingPhotos_Listings_ListingId",
                schema: "ListingHub",
                table: "ListingPhotos",
                column: "ListingId",
                principalSchema: "ListingHub",
                principalTable: "Listings",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Categories_CategoryId",
                schema: "ListingHub",
                table: "Listings",
                column: "CategoryId",
                principalSchema: "ListingHub",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_Neighbourhoods_NeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "NeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "Neighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Listings_SubNeighbourhoods_SubNeighbourhoodId",
                schema: "ListingHub",
                table: "Listings",
                column: "SubNeighbourhoodId",
                principalSchema: "ListingHub",
                principalTable: "SubNeighbourhoods",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Neighbourhoods_Districts_DistrictId",
                schema: "ListingHub",
                table: "Neighbourhoods",
                column: "DistrictId",
                principalSchema: "ListingHub",
                principalTable: "Districts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
