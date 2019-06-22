using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicsShop.DAL.Migrations
{
    public partial class Rebuild : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeComics_ComicsAuthors_ComicsAuthorId",
                table: "EmployeeComics");

            migrationBuilder.DropForeignKey(
                name: "FK_EmployeeComics_Comicses_ComicsId",
                table: "EmployeeComics");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmployeeComics",
                table: "EmployeeComics");

            migrationBuilder.RenameTable(
                name: "EmployeeComics",
                newName: "CComicsAuthorComics");

            migrationBuilder.RenameIndex(
                name: "IX_EmployeeComics_ComicsAuthorId",
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

        protected override void Down(MigrationBuilder migrationBuilder)
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
                newName: "EmployeeComics");

            migrationBuilder.RenameIndex(
                name: "IX_CComicsAuthorComics_ComicsAuthorId",
                table: "EmployeeComics",
                newName: "IX_EmployeeComics_ComicsAuthorId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmployeeComics",
                table: "EmployeeComics",
                columns: new[] { "ComicsId", "ComicsAuthorId" });

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeComics_ComicsAuthors_ComicsAuthorId",
                table: "EmployeeComics",
                column: "ComicsAuthorId",
                principalTable: "ComicsAuthors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_EmployeeComics_Comicses_ComicsId",
                table: "EmployeeComics",
                column: "ComicsId",
                principalTable: "Comicses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
