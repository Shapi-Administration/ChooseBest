using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChooseBest.Migrations.User
{
    public partial class UserChanges123 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Vote",
                table: "AspNetUsers",
                newName: "VoteTrainer");

            migrationBuilder.AddColumn<bool>(
                name: "VotePlayer",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "VoteTeam",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VotePlayer",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "VoteTeam",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "VoteTrainer",
                table: "AspNetUsers",
                newName: "Vote");
        }
    }
}
