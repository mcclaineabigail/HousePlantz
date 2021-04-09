using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class addForeignKeyIds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedPlants_Plants_PlantId",
                table: "OwnedPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedPlants_Rooms_RoomId",
                table: "OwnedPlants");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "OwnedPlants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "OwnedPlants",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedPlants_Plants_PlantId",
                table: "OwnedPlants",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedPlants_Rooms_RoomId",
                table: "OwnedPlants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OwnedPlants_Plants_PlantId",
                table: "OwnedPlants");

            migrationBuilder.DropForeignKey(
                name: "FK_OwnedPlants_Rooms_RoomId",
                table: "OwnedPlants");

            migrationBuilder.AlterColumn<int>(
                name: "RoomId",
                table: "OwnedPlants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AlterColumn<int>(
                name: "PlantId",
                table: "OwnedPlants",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedPlants_Plants_PlantId",
                table: "OwnedPlants",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_OwnedPlants_Rooms_RoomId",
                table: "OwnedPlants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
