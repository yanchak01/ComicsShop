using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace DAL.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Comicses",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    NumbersOfPages = table.Column<int>(nullable: false),
                    Description = table.Column<string>(nullable: true),
                    Seria = table.Column<string>(nullable: true),
                    DateOfProduced = table.Column<DateTime>(nullable: false),
                    Price = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Comicses", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Artists",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ComicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Artists", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Artists_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Authors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ComicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Authors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Authors_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Correctors",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ComicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Correctors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Correctors_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Illustrators",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ComicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Illustrators", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Illustrators_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Tags",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Name = table.Column<string>(nullable: true),
                    ComicsId = table.Column<Guid>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tags", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tags_Comicses_ComicsId",
                        column: x => x.ComicsId,
                        principalTable: "Comicses",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Artists_ComicsId",
                table: "Artists",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Authors_ComicsId",
                table: "Authors",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Correctors_ComicsId",
                table: "Correctors",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Illustrators_ComicsId",
                table: "Illustrators",
                column: "ComicsId");

            migrationBuilder.CreateIndex(
                name: "IX_Tags_ComicsId",
                table: "Tags",
                column: "ComicsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Artists");

            migrationBuilder.DropTable(
                name: "Authors");

            migrationBuilder.DropTable(
                name: "Correctors");

            migrationBuilder.DropTable(
                name: "Illustrators");

            migrationBuilder.DropTable(
                name: "Tags");

            migrationBuilder.DropTable(
                name: "Comicses");
        }
    }
}
