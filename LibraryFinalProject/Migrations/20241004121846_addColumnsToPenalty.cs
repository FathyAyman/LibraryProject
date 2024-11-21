using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LibraryFinalProject.Migrations
{
    /// <inheritdoc />
    public partial class addColumnsToPenalty : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TotalDelayDays",
                table: "Penalties",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "TotalPenaltyAmount",
                table: "Penalties",
                type: "real",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TotalDelayDays",
                table: "Penalties");

            migrationBuilder.DropColumn(
                name: "TotalPenaltyAmount",
                table: "Penalties");
        }
    }
}
