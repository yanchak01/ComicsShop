﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace ComicsShop.DAL.Migrations
{
    public partial class Rebuild2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<double>(
                name: "Price",
                table: "Comicses",
                nullable: false,
                oldClrType: typeof(int));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<int>(
                name: "Price",
                table: "Comicses",
                nullable: false,
                oldClrType: typeof(double));
        }
    }
}
