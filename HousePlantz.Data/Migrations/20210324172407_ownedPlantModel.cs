using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class ownedPlantModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Rooms_RoomId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "CatalogPlant");

            migrationBuilder.DropIndex(
                name: "IX_Plants_RoomId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "NickName",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Plants");

            migrationBuilder.CreateTable(
                name: "OwnedPlants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PlantId = table.Column<int>(type: "int", nullable: true),
                    NickName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    RoomId = table.Column<int>(type: "int", nullable: true),
                    CatalogId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OwnedPlants", x => x.Id);
                    table.ForeignKey(
                        name: "FK_OwnedPlants_Catalogs_CatalogId",
                        column: x => x.CatalogId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnedPlants_Plants_PlantId",
                        column: x => x.PlantId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_OwnedPlants_Rooms_RoomId",
                        column: x => x.RoomId,
                        principalTable: "Rooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_OwnedPlants_CatalogId",
                table: "OwnedPlants",
                column: "CatalogId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedPlants_PlantId",
                table: "OwnedPlants",
                column: "PlantId");

            migrationBuilder.CreateIndex(
                name: "IX_OwnedPlants_RoomId",
                table: "OwnedPlants",
                column: "RoomId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "OwnedPlants");

            migrationBuilder.AddColumn<string>(
                name: "NickName",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "CatalogPlant",
                columns: table => new
                {
                    CatalogsId = table.Column<int>(type: "int", nullable: false),
                    PlantsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CatalogPlant", x => new { x.CatalogsId, x.PlantsId });
                    table.ForeignKey(
                        name: "FK_CatalogPlant_Catalogs_CatalogsId",
                        column: x => x.CatalogsId,
                        principalTable: "Catalogs",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CatalogPlant_Plants_PlantsId",
                        column: x => x.PlantsId,
                        principalTable: "Plants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_RoomId",
                table: "Plants",
                column: "RoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CatalogPlant_PlantsId",
                table: "CatalogPlant",
                column: "PlantsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Rooms_RoomId",
                table: "Plants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
