using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    public partial class initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Books",
                columns: table => new
                {
                    ISDN = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AuthorName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsBooked = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Books", x => x.ISDN);
                });

            migrationBuilder.CreateTable(
                name: "Members",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "BookTransactions",
                columns: table => new
                {
                    TransactionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ISDN = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MemberId = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IssueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsReturned = table.Column<bool>(type: "bit", nullable: false),
                    ReturnDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    PenaltyAmount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    BooksISDN = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    MembersMemberId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookTransactions", x => x.TransactionId);
                    table.ForeignKey(
                        name: "FK_BookTransactions_Books_BooksISDN",
                        column: x => x.BooksISDN,
                        principalTable: "Books",
                        principalColumn: "ISDN");
                    table.ForeignKey(
                        name: "FK_BookTransactions_Members_MembersMemberId",
                        column: x => x.MembersMemberId,
                        principalTable: "Members",
                        principalColumn: "MemberId");
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISDN", "AuthorName", "IsBooked", "Title" },
                values: new object[,]
                {
                    { "111111111", "Dan Brown", false, "Da Vinci Code" },
                    { "222222222", "G.R.R Martin", false, "Game of Thrones" },
                    { "333333333", "george orwell", false, "1984" }
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[,]
                {
                    { -1842227606, "Rita Hammes" },
                    { -536583742, "Stevie Bruen" },
                    { 19294850, "Uriah Paucek" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_BooksISDN",
                table: "BookTransactions",
                column: "BooksISDN");

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MembersMemberId",
                table: "BookTransactions",
                column: "MembersMemberId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookTransactions");

            migrationBuilder.DropTable(
                name: "Books");

            migrationBuilder.DropTable(
                name: "Members");
        }
    }
}
