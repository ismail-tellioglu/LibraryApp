using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    public partial class transaction_update_1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
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

            migrationBuilder.AlterColumn<string>(
                name: "BookISDN",
                table: "BookTransactions",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 985252383, "Herminia Howe" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 91123923, "Ellie Waelchi" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 1803698711, "Lyric Skiles" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
                table: "BookTransactions",
                column: "BookISDN",
                principalTable: "Books",
                principalColumn: "ISDN",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
                table: "BookTransactions");

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: -985252383);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 91123923);

            migrationBuilder.DeleteData(
                table: "Members",
                keyColumn: "MemberId",
                keyValue: 1803698711);

            migrationBuilder.AlterColumn<string>(
                name: "BookISDN",
                table: "BookTransactions",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.AddColumn<string>(
                name: "ISDN",
                table: "BookTransactions",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

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

            migrationBuilder.AddForeignKey(
                name: "FK_BookTransactions_Books_BookISDN",
                table: "BookTransactions",
                column: "BookISDN",
                principalTable: "Books",
                principalColumn: "ISDN");
        }
    }
}
