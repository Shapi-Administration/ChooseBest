using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChooseBest.Migrations
{
    public partial class aboa2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Info",
                table: "Trainers");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Teams");

            migrationBuilder.DropColumn(
                name: "Info",
                table: "Players");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Trainers",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Teams",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Info",
                table: "Players",
                type: "TEXT",
                nullable: true);
        }
    }
}
