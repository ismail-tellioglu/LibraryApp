using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Db.Migrations
{
    public partial class penaltemount_removed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.DropColumn(
                name: "PenaltyAmount",
                table: "BookTransactions");

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
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.AddColumn<decimal>(
                name: "PenaltyAmount",
                table: "BookTransactions",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { -716292087, "Sage Hoppe" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 1508697910, "Augustine Veum" });

            migrationBuilder.InsertData(
                table: "Members",
                columns: new[] { "MemberId", "Name" },
                values: new object[] { 2124250356, "Kayli Schimmel" });
        }
    }
}
