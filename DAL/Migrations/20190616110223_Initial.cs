using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Comicses_ComicsId",
                table: "Authors");

            migrationBuilder.DropForeignKey(
                name: "FK_Correctors_Comicses_ComicsId",
                table: "Correctors");

            migrationBuilder.DropForeignKey(
                name: "FK_Illustrators_Comicses_ComicsId",
                table: "Illustrators");

            migrationBuilder.DropForeignKey(
                name: "FK_Tags_Comicses_ComicsId",
                table: "Tags");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Tags_ComicsId",
                table: "Tags");

            migrationBuilder.DropIndex(
                name: "IX_Illustrators_ComicsId",
                table: "Illustrators");

            migrationBuilder.DropIndex(
                name: "IX_Correctors_ComicsId",
                table: "Correctors");

            migrationBuilder.DropIndex(
                name: "IX_Authors_ComicsId",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "ComicsId",
                table: "Tags");

            migrationBuilder.DropColumn(
                name: "ComicsId",
                table: "Illustrators");

            migrationBuilder.DropColumn(
                name: "ComicsId",
                table: "Correctors");

            migrationBuilder.DropColumn(
                name: "ComicsId",
                table: "Authors");

            migrationBuilder.CreateTable(
                name: "ArtistComics",
                columns: table => new
                {
                    ArtistId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArtistComics", x => new { x.ArtistId, x.ComicsId });
                    table.ForeignKey(
                        name: "FK_ArtistComics_Artists_ArtistId",
                        column: x => x.ArtistId,
                        principalTable: "Artists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArtistComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AuthorComics",
                columns: table => new
                {
                    AuthorId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AuthorComics", x => new { x.AuthorId, x.ComicsId });
                    table.ForeignKey(
                        name: "FK_AuthorComics_Authors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "Authors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AuthorComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CorrectorComics",
                columns: table => new
                {
                    CorrectorId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CorrectorComics", x => new { x.CorrectorId, x.ComicsId });
                    table.ForeignKey(
                        name: "FK_CorrectorComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CorrectorComics_Correctors_CorrectorId",
                        column: x => x.CorrectorId,
                        principalTable: "Correctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "IllustratorComics",
                columns: table => new
                {
                    IllustratorId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_IllustratorComics", x => new { x.ComicsId, x.IllustratorId });
                    table.ForeignKey(
                        name: "FK_IllustratorComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_IllustratorComics_Illustrators_IllustratorId",
                        column: x => x.IllustratorId,
                        principalTable: "Illustrators",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    DateCreated = table.Column<DateTime>(nullable: false),
                    DateModified = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TagComics",
                columns: table => new
                {
                    TagId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TagComics", x => new { x.ComicsId, x.TagId });
                    table.ForeignKey(
                        name: "FK_TagComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TagComics_Tags_TagId",
                        column: x => x.TagId,
                        principalTable: "Tags",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "PublisherComics",
                columns: table => new
                {
                    PublisherId = table.Column<Guid>(nullable: false),
                    ComicsId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PublisherComics", x => new { x.ComicsId, x.PublisherId });
                    table.ForeignKey(
                        name: "FK_PublisherComics_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PublisherComics_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ArtistComics_ComicsId",
                table: "ArtistComics",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_AuthorComics_ComicsId",
                table: "AuthorComics",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_CorrectorComics_ComicsId",
                table: "CorrectorComics",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_IllustratorComics_IllustratorId",
                table: "IllustratorComics",
                column: "IllustratorId");

            migrationBuilder.CreateIndex(
                name: "IX_PublisherComics_PublisherId",
                table: "PublisherComics",
                column: "PublisherId");

            migrationBuilder.CreateIndex(
                name: "IX_TagComics_TagId",
                table: "TagComics",
                column: "TagId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ArtistComics");

            migrationBuilder.DropTable(
                name: "AuthorComics");

            migrationBuilder.DropTable(
                name: "CorrectorComics");

            migrationBuilder.DropTable(
                name: "IllustratorComics");

            migrationBuilder.DropTable(
                name: "PublisherComics");

            migrationBuilder.DropTable(
                name: "TagComics");

            migrationBuilder.DropTable(
                name: "Publisher");

            migrationBuilder.AddColumn<Guid>(
                name: "ComicsId",
                table: "Tags",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComicsId",
                table: "Illustrators",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComicsId",
                table: "Correctors",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "ComicsId",
                table: "Authors",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    PassWord = table.Column<string>(nullable: true),
                    UserName = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ComicsId",
                table: "Tags",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Illustrators_ComicsId",
                table: "Illustrators",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Correctors_ComicsId",
                table: "Correctors",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ComicsId",
                table: "Authors",
                column: "ComicsId");

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Comicses_ComicsId",
                table: "Authors",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Correctors_Comicses_ComicsId",
                table: "Correctors",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Illustrators_Comicses_ComicsId",
                table: "Illustrators",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Tags_Comicses_ComicsId",
                table: "Tags",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
