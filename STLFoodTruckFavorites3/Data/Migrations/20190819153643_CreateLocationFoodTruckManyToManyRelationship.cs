using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace STLFoodTruckFavorites3.Data.Migrations
{
    public partial class CreateLocationFoodTruckManyToManyRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LocationFoodTrucks",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    LocationID = table.Column<int>(nullable: false),
                    FoodTruckID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LocationFoodTrucks", x => x.ID);
                    table.ForeignKey(
                        name: "FK_LocationFoodTrucks_FoodTrucks_FoodTruckID",
                        column: x => x.FoodTruckID,
                        principalTable: "FoodTrucks",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_LocationFoodTrucks_Locations_LocationID",
                        column: x => x.LocationID,
                        principalTable: "Locations",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_LocationFoodTrucks_FoodTruckID",
                table: "LocationFoodTrucks",
                column: "FoodTruckID");

            migrationBuilder.CreateIndex(
                name: "IX_LocationFoodTrucks_LocationID",
                table: "LocationFoodTrucks",
                column: "LocationID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LocationFoodTrucks");
        }
    }
}
