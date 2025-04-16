using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace InternetCafe.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsingViewModelId",
                table: "User",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "UsingViewModelId",
                table: "Computer",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ActiveUserComputer",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ActiveUserComputer", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_UsingViewModelId",
                table: "User",
                column: "UsingViewModelId");

            migrationBuilder.CreateIndex(
                name: "IX_Computer_UsingViewModelId",
                table: "Computer",
                column: "UsingViewModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Computer_ActiveUserComputer_UsingViewModelId",
                table: "Computer",
                column: "UsingViewModelId",
                principalTable: "ActiveUserComputer",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_ActiveUserComputer_UsingViewModelId",
                table: "User",
                column: "UsingViewModelId",
                principalTable: "ActiveUserComputer",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Computer_ActiveUserComputer_UsingViewModelId",
                table: "Computer");

            migrationBuilder.DropForeignKey(
                name: "FK_User_ActiveUserComputer_UsingViewModelId",
                table: "User");

            migrationBuilder.DropTable(
                name: "ActiveUserComputer");

            migrationBuilder.DropIndex(
                name: "IX_User_UsingViewModelId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_Computer_UsingViewModelId",
                table: "Computer");

            migrationBuilder.DropColumn(
                name: "UsingViewModelId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "UsingViewModelId",
                table: "Computer");

            migrationBuilder.AlterColumn<string>(
                name: "Username",
                table: "User",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AlterColumn<string>(
                name: "PhoneNumber",
                table: "User",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");
        }
    }
}
