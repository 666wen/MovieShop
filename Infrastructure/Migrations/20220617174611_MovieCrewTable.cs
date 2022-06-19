using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Infrastructure.Migrations
{
    public partial class MovieCrewTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieMovieCrew");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movie_MovieCrew_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie");

            migrationBuilder.DropIndex(
                name: "IX_Movie_MovieCrewMovieId_MovieCrewCrewId_MovieCrewDepartment_MovieCrewJob",
                table: "Movie");

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

            migrationBuilder.CreateTable(
                name: "MovieMovieCrew",
                columns: table => new
                {
                    MovieIDId = table.Column<int>(type: "int", nullable: false),
                    MovieCrewersMovieId = table.Column<int>(type: "int", nullable: false),
                    MovieCrewersCrewId = table.Column<int>(type: "int", nullable: false),
                    MovieCrewersDepartment = table.Column<string>(type: "nvarchar(128)", nullable: false),
                    MovieCrewersJob = table.Column<string>(type: "nvarchar(128)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieMovieCrew", x => new { x.MovieIDId, x.MovieCrewersMovieId, x.MovieCrewersCrewId, x.MovieCrewersDepartment, x.MovieCrewersJob });
                    table.ForeignKey(
                        name: "FK_MovieMovieCrew_Movie_MovieIDId",
                        column: x => x.MovieIDId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieMovieCrew_MovieCrew_MovieCrewersMovieId_MovieCrewersCrewId_MovieCrewersDepartment_MovieCrewersJob",
                        columns: x => new { x.MovieCrewersMovieId, x.MovieCrewersCrewId, x.MovieCrewersDepartment, x.MovieCrewersJob },
                        principalTable: "MovieCrew",
                        principalColumns: new[] { "MovieId", "CrewId", "Department", "Job" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieMovieCrew_MovieCrewersMovieId_MovieCrewersCrewId_MovieCrewersDepartment_MovieCrewersJob",
                table: "MovieMovieCrew",
                columns: new[] { "MovieCrewersMovieId", "MovieCrewersCrewId", "MovieCrewersDepartment", "MovieCrewersJob" });
        }
    }
}
