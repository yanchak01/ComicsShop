using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicsShop.DAL.Migrations
{
    public partial class RenameCComics_Comics : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CComicsAuthorComics_ComicsAuthors_ComicsAuthorId",
                table: "CComicsAuthorComics");

            migrationBuilder.DropForeignKey(
                name: "FK_CComicsAuthorComics_Comicses_ComicsId",
                table: "CComicsAuthorComics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CComicsAuthorComics",
                table: "CComicsAuthorComics");

            migrationBuilder.RenameTable(
                name: "CComicsAuthorComics",
                newName: "ComicsAuthorComics");

            migrationBuilder.RenameIndex(
                name: "IX_CComicsAuthorComics_ComicsAuthorId",
                table: "ComicsAuthorComics",
                newName: "IX_ComicsAuthorComics_ComicsAuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ComicsAuthorComics",
                table: "ComicsAuthorComics",
                columns: new[] { "ComicsId", "ComicsAuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_ComicsAuthorComics_ComicsAuthors_ComicsAuthorId",
                table: "ComicsAuthorComics",
                column: "ComicsAuthorId",
                principalTable: "ComicsAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ComicsAuthorComics_Comicses_ComicsId",
                table: "ComicsAuthorComics",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ComicsAuthorComics_ComicsAuthors_ComicsAuthorId",
                table: "ComicsAuthorComics");

            migrationBuilder.DropForeignKey(
                name: "FK_ComicsAuthorComics_Comicses_ComicsId",
                table: "ComicsAuthorComics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ComicsAuthorComics",
                table: "ComicsAuthorComics");

            migrationBuilder.RenameTable(
                name: "ComicsAuthorComics",
                newName: "CComicsAuthorComics");

            migrationBuilder.RenameIndex(
                name: "IX_ComicsAuthorComics_ComicsAuthorId",
                table: "CComicsAuthorComics",
                newName: "IX_CComicsAuthorComics_ComicsAuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CComicsAuthorComics",
                table: "CComicsAuthorComics",
                columns: new[] { "ComicsId", "ComicsAuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_CComicsAuthorComics_ComicsAuthors_ComicsAuthorId",
                table: "CComicsAuthorComics",
                column: "ComicsAuthorId",
                principalTable: "ComicsAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_CComicsAuthorComics_Comicses_ComicsId",
                table: "CComicsAuthorComics",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
