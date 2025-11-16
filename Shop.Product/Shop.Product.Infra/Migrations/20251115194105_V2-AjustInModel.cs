using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shop.Product.Infra.Migrations
{
    /// <inheritdoc />
    public partial class V2AjustInModel : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "IdCategory",
                table: "Products",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdCategory",
                table: "Products");
        }
    }
}
