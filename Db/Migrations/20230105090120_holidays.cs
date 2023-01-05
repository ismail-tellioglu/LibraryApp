using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    public partial class holidays : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "111111111");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "222222222");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "333333333");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 134574846);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 270270348);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 686120357);

            migrationBuilder.CreateTable(
                name: "Holidays",
                columns: table => new
                {
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Holidays", x => x.Date);
                });

            migrationBuilder.InsertData(
                table: "Books",
                columns: new[] { "ISDN", "AuthorName", "IsBooked", "Title" },
                values: new object[,]
                {
                    { "0000", "Dan Brown", false, "Da Vinci Code" },
                    { "1111", "G.R.R Martin", false, "Game of Thrones" },
                    { "2222", "George Orwell", false, "1984" },
                    { "3333", "Edith Wharton", false, "The House of Mirth" },
                    { "4444", "Ernest Hemingway", false, "The Sun Also Rises" },
                    { "5555", "Lois Lowry", false, "Number the Stars" },
                    { "6666", "Aldous Huxley", false, "Brave New World" },
                    { "7777", "Vladimir Nabokov", false, "Pale Fire" },
                    { "8888", "Stella Gibbons", false, "Cold Comfort Farm" },
                    { "99999", "Margaret Mitchell", false, "Gone With the Wind " }
                });

            migrationBuilder.InsertData(
                table: "Holidays",
                column: "Date",
                values: new object[]
                {
                    new DateTime(2023, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 4, 21, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 4, 22, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 4, 23, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 5, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 5, 19, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 6, 28, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 6, 29, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 6, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 7, 1, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 7, 15, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 8, 30, 0, 0, 0, 0, DateTimeKind.Unspecified),
                    new DateTime(2023, 10, 29, 0, 0, 0, 0, DateTimeKind.Unspecified)
                });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[,]
                {
                    { -716292087, "Sage Hoppe" },
                    { 1508697910, "Augustine Veum" },
                    { 2124250356, "Kayli Schimmel" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Holidays");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "0000");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "1111");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "2222");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "3333");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "4444");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "5555");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "6666");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "7777");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "8888");

            migrationBuilder.DeleteData(
                table: "Books",
                keyColumn: "ISDN",
                keyValue: "99999");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: -716292087);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1508697910);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 2124250356);

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
                    { 134574846, "Brooke Osinski" },
                    { 270270348, "Immanuel Stark" },
                    { 686120357, "Tom Hand" }
                });
        }
    }
}
