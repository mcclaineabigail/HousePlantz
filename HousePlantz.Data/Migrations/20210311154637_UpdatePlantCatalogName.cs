using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class UpdatePlantCatalogName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogPlant_PlantCatalogs_CatalogsId",
                table: "CatalogPlant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_PlantCatalogs",
                table: "PlantCatalogs");

            migrationBuilder.RenameTable(
                name: "PlantCatalogs",
                newName: "Catalogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogPlant_Catalogs_CatalogsId",
                table: "CatalogPlant",
                column: "CatalogsId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CatalogPlant_Catalogs_CatalogsId",
                table: "CatalogPlant");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Catalogs",
                table: "Catalogs");

            migrationBuilder.RenameTable(
                name: "Catalogs",
                newName: "PlantCatalogs");

            migrationBuilder.AddPrimaryKey(
                name: "PK_PlantCatalogs",
                table: "PlantCatalogs",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_CatalogPlant_PlantCatalogs_CatalogsId",
                table: "CatalogPlant",
                column: "CatalogsId",
                principalTable: "PlantCatalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
