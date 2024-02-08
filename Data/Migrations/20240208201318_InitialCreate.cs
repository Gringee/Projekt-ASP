using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "photos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Data = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Opis = table.Column<string>(type: "TEXT", maxLength: 100, nullable: false),
                    Aparat = table.Column<string>(type: "TEXT", maxLength: 30, nullable: false),
                    Autor = table.Column<string>(type: "TEXT", nullable: false),
                    Resolution = table.Column<string>(type: "TEXT", nullable: false),
                    Format = table.Column<string>(type: "TEXT", nullable: false),
                    Priority = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_photos", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "photos",
                columns: new[] { "Id", "Aparat", "Autor", "Data", "Format", "Opis", "Priority", "Resolution" },
                values: new object[,]
                {
                    { 1, "Nikon", "Adam", new DateTime(2000, 10, 10, 0, 0, 0, 0, DateTimeKind.Unspecified), "4x3", "zdjęcie z tatr", 2, "800x600" },
                    { 2, "Samsung", "Paweł", new DateTime(2022, 11, 12, 0, 0, 0, 0, DateTimeKind.Unspecified), "16x9", "zdjęcie z rodziną", 1, "1920x1080" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "photos");
        }
    }
}
