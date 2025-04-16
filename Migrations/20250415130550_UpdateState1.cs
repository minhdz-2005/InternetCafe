using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetCafe.Migrations
{
    /// <inheritdoc />
    public partial class UpdateState1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Revenue",
                table: "Computer",
                type: "decimal(18,2)",
                precision: 18,
                scale: 2,
                nullable: false,
                defaultValue: 0m);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Revenue",
                table: "Computer");
        }
    }
}
