using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChooseBest.Migrations
{
    public partial class AddedModels4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Trainers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Teams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Img",
                table: "Players",
                type: "TEXT",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Img",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Img",
                table: "Players");
        }
    }
}
