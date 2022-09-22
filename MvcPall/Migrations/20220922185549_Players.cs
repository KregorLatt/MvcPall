using Microsoft.EntityFrameworkCore.Migrations;

namespace MvcPall.Migrations
{
    public partial class Players : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "size",
                table: "Ball",
                newName: "Size");

            migrationBuilder.RenameColumn(
                name: "color",
                table: "Ball",
                newName: "Color");

            migrationBuilder.AddColumn<string>(
                name: "Players",
                table: "Ball",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Players",
                table: "Ball");

            migrationBuilder.RenameColumn(
                name: "Size",
                table: "Ball",
                newName: "size");

            migrationBuilder.RenameColumn(
                name: "Color",
                table: "Ball",
                newName: "color");
        }
    }
}
