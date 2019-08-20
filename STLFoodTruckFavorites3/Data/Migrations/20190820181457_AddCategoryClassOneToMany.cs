using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLFoodTruckFavorites3.Data.Migrations
{
    public partial class AddCategoryClassOneToMany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CategoryID",
                table: "FoodTrucks",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Categories",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    CategoryName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Categories", x => x.ID);
                });

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FoodTrucks_Categories_CategoryID",
                table: "FoodTrucks");

            migrationBuilder.DropTable(
                name: "Categories");

            migrationBuilder.DropIndex(
                name: "IX_FoodTrucks_CategoryID",
                table: "FoodTrucks");

            migrationBuilder.DropColumn(
                name: "CategoryID",
                table: "FoodTrucks");
        }
    }
}
