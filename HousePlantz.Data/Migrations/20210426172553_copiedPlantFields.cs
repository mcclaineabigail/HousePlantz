using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class copiedPlantFields : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "OwnedPlants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Sun",
                table: "OwnedPlants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "OwnedPlants");

            migrationBuilder.DropColumn(
                name: "Sun",
                table: "OwnedPlants");
        }
    }
}
