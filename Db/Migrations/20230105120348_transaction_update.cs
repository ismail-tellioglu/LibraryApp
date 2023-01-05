using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    public partial class transaction_update : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_BooksISDN",
                table: "BookTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Members_MembersMemberId",
                table: "BookTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BookTransactions_MembersMemberId",
                table: "BookTransactions");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 102165447);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 778270072);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1001160879);

            migrationBuilder.DropColumn(
                name: "MembersMemberId",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "BooksISDN",
                table: "BookTransactions",
                newName: "BookISDN");

            migrationBuilder.RenameIndex(
                name: "IX_BookTransactions_BooksISDN",
                table: "BookTransactions",
                newName: "IX_BookTransactions_BookISDN");

            migrationBuilder.AddColumn<string>(
                name: "ISDN",
                table: "BookTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "MemberId",
                table: "BookTransactions",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { -1928409352, "Fay Hammes" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 704951729, "Bernita Denesik" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 1059032368, "Juston Treutel" });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions",
                column: "MemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
                table: "BookTransactions",
                column: "BookISDN",
                principalTable: "Books",
                principalColumn: "ISDN");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Members_MemberId",
                table: "BookTransactions",
                column: "MemberId",
                principalTable: "Members",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
                table: "BookTransactions");

            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Members_MemberId",
                table: "BookTransactions");

            migrationBuilder.DropIndex(
                name: "IX_BookTransactions_MemberId",
                table: "BookTransactions");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: -1928409352);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 704951729);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1059032368);

            migrationBuilder.DropColumn(
                name: "ISDN",
                table: "BookTransactions");

            migrationBuilder.DropColumn(
                name: "MemberId",
                table: "BookTransactions");

            migrationBuilder.RenameColumn(
                name: "BookISDN",
                table: "BookTransactions",
                newName: "BooksISDN");

            migrationBuilder.RenameIndex(
                name: "IX_BookTransactions_BookISDN",
                table: "BookTransactions",
                newName: "IX_BookTransactions_BooksISDN");

            migrationBuilder.AddColumn<int>(
                name: "MembersMemberId",
                table: "BookTransactions",
                type: "int",
                nullable: true);

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 102165447, "John Schuster" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 778270072, "Lilian Kemmer" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 1001160879, "London Crona" });

            migrationBuilder.CreateIndex(
                name: "IX_BookTransactions_MembersMemberId",
                table: "BookTransactions",
                column: "MembersMemberId");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_BooksISDN",
                table: "BookTransactions",
                column: "BooksISDN",
                principalTable: "Books",
                principalColumn: "ISDN");

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Members_MembersMemberId",
                table: "BookTransactions",
                column: "MembersMemberId",
                principalTable: "Members",
                principalColumn: "MemberId");
        }
    }
}
