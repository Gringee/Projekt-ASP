using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photos");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Photos",
                table: "Photos");

            migrationBuilder.RenameTable(
                name: "Photos",
                newName: "photos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_photos",
                table: "photos",
                column: "Id");

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "Id", "Aparat", "Autor", "Data", "Format", "Opis", "Resolution" },
                values: new object[] { 1, "Nikon", "Adam", new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "16x9", "zdjecie z tatr", "1920x1080" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_photos",
                table: "photos");

            migrationBuilder.DeleteData(
                table: "photos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.RenameTable(
                name: "photos",
                newName: "Photos");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Photos",
                table: "Photos",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Aparat = table.Column<string>(type: "TEXT", nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Data = table.Column<DateTime>(type: "TEXT", maxLength: 50, nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "Id", "Aparat", "Autor", "Data", "Format", "Opis", "Resolution" },
                values: new object[] { 1, "Nikon", "Adam", new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "16x9", "zdjecie z tatr", "1920x1080" });
        }
    }
}
