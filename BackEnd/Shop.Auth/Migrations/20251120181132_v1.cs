using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Auth.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "NVARCHAR(250)", maxLength: 250, nullable: false),
                    Email_Address = table.Column<string>(type: "NVARCHAR(300)", maxLength: 300, nullable: false),
                    PasswordHash = table.Column<string>(type: "NVARCHAR(400)", maxLength: 400, nullable: true),
                    Roles = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Google = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
