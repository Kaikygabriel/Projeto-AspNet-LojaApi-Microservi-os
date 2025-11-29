using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Auth.Migrations
{
    /// <inheritdoc />
    public partial class FinalVersion102 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email",
                table: "Users",
                newName: "Email_Address");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Email_Address",
                table: "Users",
                newName: "Email");
        }
    }
}
