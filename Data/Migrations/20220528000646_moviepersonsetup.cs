using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace MovieCatalogueApp.Data.Migrations
{
    public partial class moviepersonsetup : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "MoviePerson",
                columns: table => new
                {
                    CastAndCrewId = table.Column<int>(type: "int", nullable: false),
                    MoviesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MoviePerson", x => new { x.CastAndCrewId, x.MoviesId });
                    table.ForeignKey(
                        name: "FK_MoviePerson_Movie_MoviesId",
                        column: x => x.MoviesId,
                        principalTable: "Movie",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MoviePerson_Person_CastAndCrewId",
                        column: x => x.CastAndCrewId,
                        principalTable: "Person",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MoviePerson_MoviesId",
                table: "MoviePerson",
                column: "MoviesId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MoviePerson");
        }
    }
}
