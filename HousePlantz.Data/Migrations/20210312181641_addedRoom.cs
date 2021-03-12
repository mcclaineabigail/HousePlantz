using Microsoft.EntityFrameworkCore.Migrations;

namespace HousePlantz.Data.Migrations
{
    public partial class addedRoom : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Color",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Room",
                table: "Plants");

            migrationBuilder.AddColumn<int>(
                name: "RoomId",
                table: "Plants",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoomName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Color = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Plants_RoomId",
                table: "Plants",
                column: "RoomId");

            migrationBuilder.AddForeignKey(
                name: "FK_Plants_Rooms_RoomId",
                table: "Plants",
                column: "RoomId",
                principalTable: "Rooms",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Plants_Rooms_RoomId",
                table: "Plants");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Plants_RoomId",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "RoomId",
                table: "Plants");

            migrationBuilder.AddColumn<string>(
                name: "Color",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Room",
                table: "Plants",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
