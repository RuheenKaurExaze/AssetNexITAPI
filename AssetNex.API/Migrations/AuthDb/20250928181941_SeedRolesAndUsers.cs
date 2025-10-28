using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AssetNex.API.Migrations.AuthDb
{
    /// <inheritdoc />
    public partial class SeedRolesAndUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61f8473-db02-4312-b6a5-5871844da9cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "STATIC-CONCURRENCY-STAMP-12345", "AQAAAAIAAYagAAAAECksSwnnAph3F8RGFvP/wLJx8lQRTdTt0ttF2rWb6lM3MJfZ7X8Zj/olc/Jlz2twPw==", "STATIC-SECURITY-STAMP-12345" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "AspNetUsers",
                keyColumn: "Id",
                keyValue: "f61f8473-db02-4312-b6a5-5871844da9cf",
                columns: new[] { "ConcurrencyStamp", "PasswordHash", "SecurityStamp" },
                values: new object[] { "743c702b-693d-4f05-8c2a-1fbbd31e0b9d", "AQAAAAIAAYagAAAAEC+QFK9Gjuxv+pnU1RQQKmDr/T5/QDKvNpK/c4qohOyH4HycPREjBqKHmsvbYa7DDg==", "09666431-d918-40b9-8f6b-9f2f9cf911df" });
        }
    }
}
 