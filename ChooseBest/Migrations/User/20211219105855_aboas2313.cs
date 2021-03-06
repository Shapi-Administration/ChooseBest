using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ChooseBest.Migrations.User
{
    public partial class aboas2313 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Player_ChosenPlayerId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Team_ChosenTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Trainer_ChosenTrainerId",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Player");

            migrationBuilder.DropTable(
                name: "Team");

            migrationBuilder.DropTable(
                name: "Trainer");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChosenPlayerId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChosenTeamId",
                table: "AspNetUsers");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_ChosenTrainerId",
                table: "AspNetUsers");

            migrationBuilder.RenameColumn(
                name: "ChosenTrainerId",
                table: "AspNetUsers",
                newName: "ChosenTrainer");

            migrationBuilder.RenameColumn(
                name: "ChosenTeamId",
                table: "AspNetUsers",
                newName: "ChosenTeam");

            migrationBuilder.RenameColumn(
                name: "ChosenPlayerId",
                table: "AspNetUsers",
                newName: "ChosenPlayer");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ChosenTrainer",
                table: "AspNetUsers",
                newName: "ChosenTrainerId");

            migrationBuilder.RenameColumn(
                name: "ChosenTeam",
                table: "AspNetUsers",
                newName: "ChosenTeamId");

            migrationBuilder.RenameColumn(
                name: "ChosenPlayer",
                table: "AspNetUsers",
                newName: "ChosenPlayerId");

            migrationBuilder.CreateTable(
                name: "Player",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Img = table.Column<string>(type: "TEXT", nullable: true),
                    Info = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TeamInfo = table.Column<string>(type: "TEXT", nullable: true),
                    Votes = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Player", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Team",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Img = table.Column<string>(type: "TEXT", nullable: true),
                    Info = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    Votes = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Team", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Trainer",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "TEXT", nullable: false),
                    Age = table.Column<int>(type: "INTEGER", nullable: true),
                    Img = table.Column<string>(type: "TEXT", nullable: true),
                    Info = table.Column<string>(type: "TEXT", nullable: true),
                    Name = table.Column<string>(type: "TEXT", nullable: true),
                    TeamInfo = table.Column<string>(type: "TEXT", nullable: true),
                    Votes = table.Column<uint>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Trainer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChosenPlayerId",
                table: "AspNetUsers",
                column: "ChosenPlayerId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChosenTeamId",
                table: "AspNetUsers",
                column: "ChosenTeamId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_ChosenTrainerId",
                table: "AspNetUsers",
                column: "ChosenTrainerId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Player_ChosenPlayerId",
                table: "AspNetUsers",
                column: "ChosenPlayerId",
                principalTable: "Player",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Team_ChosenTeamId",
                table: "AspNetUsers",
                column: "ChosenTeamId",
                principalTable: "Team",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Trainer_ChosenTrainerId",
                table: "AspNetUsers",
                column: "ChosenTrainerId",
                principalTable: "Trainer",
                principalColumn: "Id");
        }
    }
}
