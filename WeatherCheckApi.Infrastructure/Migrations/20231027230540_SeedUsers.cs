using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace WeatherCheckApi.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class SeedUsers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Id", "Email", "Password" },
               values: new object[] { 1, "user@mail.com", BCrypt.Net.BCrypt.HashPassword("password123") }
           );

            migrationBuilder.InsertData(
               table: "Users",
               columns: new[] { "Id", "Email", "Password" },
               values: new object[] { 2, "user2@mail.com", BCrypt.Net.BCrypt.HashPassword("password123") }
           );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
