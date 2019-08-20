using Microsoft.EntityFrameworkCore.Migrations;

namespace STLFoodTruckFavorites3.Data.Migrations
{
    public partial class AddCategoryClassOneToManyFoodTruck : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTrucks_Categories_CategoryID",
                table: "FoodTrucks");

            migrationBuilder.DropIndex(
                name: "IX_FoodTrucks_CategoryID",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "FoodTrucks");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FoodTrucks_CategoryID",
                table: "FoodTrucks",
                column: "CategoryID");

            migrationBuilder.AddForeignKey(
                name: "FK_FoodTrucks_Categories_CategoryID",
                table: "FoodTrucks",
                column: "CategoryID",
                principalTable: "Categories",
                principalColumn: "ID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
