using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class addUserNameToMemberAndLibrarian : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Members",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "UserName",
                table: "Librarians",
                type: "nvarchar(max)",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Members");

            migrationBuilder.DropColumn(
                name: "UserName",
                table: "Librarians");
        }
    }
}
