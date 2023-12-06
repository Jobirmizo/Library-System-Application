using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Library_System_Application.Migrations
{
    /// <inheritdoc />
    public partial class initialMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "author",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false),
                    last_name = table.Column<string>(type: "varchar(1)", unicode: false, maxLength: 1, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__author__3214EC27EA465A5E", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "category",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__category__3214EC2749D075E5", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "manager",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    username = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    password = table.Column<string>(type: "char(5)", unicode: false, fixedLength: true, maxLength: 5, nullable: false),
                    okey = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__manager__3214EC27DD4F7513", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "student",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    first_name = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: false),
                    last_name = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: false),
                    phone = table.Column<string>(type: "char(13)", unicode: false, fixedLength: true, maxLength: 13, nullable: false),
                    email = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    id_card = table.Column<string>(type: "char(7)", unicode: false, fixedLength: true, maxLength: 7, nullable: false),
                    passport = table.Column<string>(type: "char(9)", unicode: false, fixedLength: true, maxLength: 9, nullable: false),
                    role = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__student__3214EC272B6D402A", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "books",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    title = table.Column<string>(type: "varchar(255)", unicode: false, maxLength: 255, nullable: false),
                    publication_year = table.Column<string>(type: "varchar(4)", unicode: false, maxLength: 4, nullable: false),
                    language = table.Column<string>(type: "varchar(55)", unicode: false, maxLength: 55, nullable: false),
                    categoryID = table.Column<int>(type: "int", nullable: false),
                    copies_owned = table.Column<int>(type: "int", nullable: false),
                    count = table.Column<int>(type: "int", nullable: true),
                    image = table.Column<byte[]>(type: "image", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__books__3214EC273F96C019", x => x.ID);
                    table.ForeignKey(
                        name: "FK__books__categoryI__5BE2A6F2",
                        column: x => x.categoryID,
                        principalTable: "category",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "loan",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    studentID = table.Column<int>(type: "int", nullable: false),
                    bookID = table.Column<int>(type: "int", nullable: false),
                    borrow_date = table.Column<DateTime>(type: "date", nullable: true),
                    return_date = table.Column<DateTime>(type: "date", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__loan__3214EC27B63496D0", x => x.ID);
                    table.ForeignKey(
                        name: "FK__loan__bookID__72C60C4A",
                        column: x => x.bookID,
                        principalTable: "student",
                        principalColumn: "id");
                    table.ForeignKey(
                        name: "FK__loan__studentID__71D1E811",
                        column: x => x.studentID,
                        principalTable: "student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateTable(
                name: "book_author",
                columns: table => new
                {
                    booksID = table.Column<int>(type: "int", nullable: false),
                    auithotr = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        name: "FK__book_auth__auith__619B8048",
                        column: x => x.auithotr,
                        principalTable: "author",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__book_auth__books__60A75C0F",
                        column: x => x.booksID,
                        principalTable: "books",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateTable(
                name: "reservation",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    booksID = table.Column<int>(type: "int", nullable: false),
                    studentID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK__reservat__3214EC2721CC7E84", x => x.ID);
                    table.ForeignKey(
                        name: "FK__reservati__books__6E01572D",
                        column: x => x.booksID,
                        principalTable: "books",
                        principalColumn: "ID");
                    table.ForeignKey(
                        name: "FK__reservati__stude__6EF57B66",
                        column: x => x.studentID,
                        principalTable: "student",
                        principalColumn: "id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_book_author_auithotr",
                table: "book_author",
                column: "auithotr");

            migrationBuilder.CreateIndex(
                name: "IX_book_author_booksID",
                table: "book_author",
                column: "booksID");

            migrationBuilder.CreateIndex(
                name: "IX_books_categoryID",
                table: "books",
                column: "categoryID");

            migrationBuilder.CreateIndex(
                name: "IX_loan_bookID",
                table: "loan",
                column: "bookID");

            migrationBuilder.CreateIndex(
                name: "IX_loan_studentID",
                table: "loan",
                column: "studentID");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_booksID",
                table: "reservation",
                column: "booksID");

            migrationBuilder.CreateIndex(
                name: "IX_reservation_studentID",
                table: "reservation",
                column: "studentID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "book_author");

            migrationBuilder.DropTable(
                name: "loan");

            migrationBuilder.DropTable(
                name: "manager");

            migrationBuilder.DropTable(
                name: "reservation");

            migrationBuilder.DropTable(
                name: "author");

            migrationBuilder.DropTable(
                name: "books");

            migrationBuilder.DropTable(
                name: "student");

            migrationBuilder.DropTable(
                name: "category");
        }
    }
}
