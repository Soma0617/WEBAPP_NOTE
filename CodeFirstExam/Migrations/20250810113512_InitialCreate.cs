using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodeFirstExam.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    BookID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Photo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.BookID);
                });

            migrationBuilder.CreateTable(
                name: "ReBooks",
                columns: table => new
                {
                    ReBookID = table.Column<string>(type: "nvarchar(36)", maxLength: 36, nullable: false),
                    Discription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Author = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CreateDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    BookID = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BooksBookID = table.Column<string>(type: "nvarchar(36)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ReBooks", x => x.ReBookID);
                    table.ForeignKey(
                        name: "FK_ReBooks_Books_BooksBookID",
                        column: x => x.BooksBookID,
                        principalTable: "Books",
                        principalColumn: "BookID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ReBooks_BooksBookID",
                table: "ReBooks",
                column: "BooksBookID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ReBooks");

            migrationBuilder.DropTable(
                name: "Books");
        }
    }
}
