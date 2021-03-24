using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class addedCatalogListBack : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Catalogs_CatalogId",
                table: "Plants");

            migrationBuilder.DropIndex(
                name: "IX_Plants_CatalogId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "CatalogId",
                table: "Plants");

            migrationBuilder.CreateTable(
                name: "CatalogPlant",
                columns: table => new
                {
                    CatalogsId = table.Column<long>(type: "bigint", nullable: false),
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
                name: "IX_CatalogPlant_PlantsId",
                table: "CatalogPlant",
                column: "PlantsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CatalogPlant");

            migrationBuilder.AddColumn<long>(
                name: "CatalogId",
                table: "Plants",
                type: "bigint",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Plants_CatalogId",
                table: "Plants",
                column: "CatalogId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Catalogs_CatalogId",
                table: "Plants",
                column: "CatalogId",
                principalTable: "Catalogs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
