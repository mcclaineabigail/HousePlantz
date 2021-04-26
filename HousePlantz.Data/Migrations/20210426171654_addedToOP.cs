using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class addedToOP : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "OwnedPlants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "OwnedPlants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Water",
                table: "OwnedPlants",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Image",
                table: "OwnedPlants");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "OwnedPlants");

            migrationBuilder.DropColumn(
                name: "Water",
                table: "OwnedPlants");
        }
    }
}
