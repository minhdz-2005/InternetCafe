using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetCafe.Migrations
{
    /// <inheritdoc />
    public partial class lai1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "IdUser",
                table: "ActiveUserComputer",
                newName: "UserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "UserId",
                table: "ActiveUserComputer",
                newName: "IdUser");
        }
    }
}
