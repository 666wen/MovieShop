using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MovieCastTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieCrew_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer");

            migrationBuilder.DropIndex(
                name: "IX_Movie_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer");

            migrationBuilder.DropColumn(
                name: "MovieCrewCrewId",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieCrewDepartment",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieCrewJob",
                table: "Movie");

            migrationBuilder.DropColumn(
                name: "MovieCrewMovieId",
                table: "Movie");

            migrationBuilder.RenameTable(
                name: "Trailer",
                newName: "Trailers");

            migrationBuilder.RenameIndex(
                name: "IX_Trailer_MovieId",
                table: "Trailers",
                newName: "IX_Trailers_MovieId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MovieCrew_Movie_MovieId",
                table: "MovieCrew",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Trailers_Movie_MovieId",
                table: "Trailers",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MovieCrew_Movie_MovieId",
                table: "MovieCrew");

            migrationBuilder.DropForeignKey(
                name: "FK_Trailers_Movie_MovieId",
                table: "Trailers");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Trailers",
                table: "Trailers");

            migrationBuilder.RenameTable(
                name: "Trailers",
                newName: "Trailer");

            migrationBuilder.RenameIndex(
                name: "IX_Trailers_MovieId",
                table: "Trailer",
                newName: "IX_Trailer_MovieId");

            migrationBuilder.AddColumn<int>(
                name: "MovieCrewCrewId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieCrewDepartment",
                table: "Movie",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "MovieCrewJob",
                table: "Movie",
                type: "nvarchar(128)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "MovieCrewMovieId",
                table: "Movie",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Trailer",
                table: "Trailer",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Movie_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie",
                columns: new[] { "MovieCrewMovieId", "MovieCrewCrewId", "MovieCrewDepartment", "MovieCrewJob" });

            migrationBuilder.AddForeignKey(
                name: "FK_Movie_MovieCrew_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie",
                columns: new[] { "MovieCrewMovieId", "MovieCrewCrewId", "MovieCrewDepartment", "MovieCrewJob" },
                principalTable: "MovieCrew",
                principalColumns: new[] { "MovieId", "CrewId", "Department", "Job" });

            migrationBuilder.AddForeignKey(
                name: "FK_Trailer_Movie_MovieId",
                table: "Trailer",
                column: "MovieId",
                principalTable: "Movie",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
