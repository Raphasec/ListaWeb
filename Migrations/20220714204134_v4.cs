using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Aula14.Migrations
{
    public partial class v4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Genre",
                table: "Movies");

            migrationBuilder.AddColumn<int>(
                name: "IdGenre",
                table: "Movies",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Movies_IdGenre",
                table: "Movies",
                column: "IdGenre");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_Genres_IdGenre",
                table: "Movies",
                column: "IdGenre",
                principalTable: "Genres",
                principalColumn: "IdGenre",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_Genres_IdGenre",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_IdGenre",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "IdGenre",
                table: "Movies");

            migrationBuilder.AddColumn<string>(
                name: "Genre",
                table: "Movies",
                type: "TEXT",
                maxLength: 32,
                nullable: false,
                defaultValue: "");
        }
    }
}
