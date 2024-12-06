using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TradianBackend.Migrations
{
    /// <inheritdoc />
    public partial class AddedSecurePosts : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsSecured",
                table: "Posts",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsSecured",
                table: "Posts");
        }
    }
}
