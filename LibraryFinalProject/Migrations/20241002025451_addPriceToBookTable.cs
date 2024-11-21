using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class addPriceToBookTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<double>(
                name: "PricePerWeek",
                table: "Books",
                type: "float",
                nullable: false,
                defaultValue: 10.0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricePerWeek",
                table: "Books");
        }
    }
}
