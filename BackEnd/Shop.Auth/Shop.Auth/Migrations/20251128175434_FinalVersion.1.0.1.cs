using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Auth.Migrations
{
    /// <inheritdoc />
    public partial class FinalVersion101 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email_Address",
                table: "Users",
                newName: "Email");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Email_Address");
        }
    }
}
