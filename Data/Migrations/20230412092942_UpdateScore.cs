using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Highscore.Migrations
{
    /// <inheritdoc />
    public partial class UpdateScore : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "bae8cdee-800e-4fc5-953d-745cb9266b11");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Score",
                newName: "UserName");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "36131752-131e-46d2-8768-8822416a114f", null, "Administrator", null });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "AspNetRoles",
                keyColumn: "Id",
                keyValue: "36131752-131e-46d2-8768-8822416a114f");

            migrationBuilder.RenameColumn(
                name: "UserName",
                table: "Score",
                newName: "Name");

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[] { "bae8cdee-800e-4fc5-953d-745cb9266b11", null, "Administrator", null });
        }
    }
}
