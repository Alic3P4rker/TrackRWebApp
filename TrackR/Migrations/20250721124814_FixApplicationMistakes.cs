using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrackR.Migrations
{
    /// <inheritdoc />
    public partial class FixApplicationMistakes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Postion",
                table: "Applications",
                newName: "Position");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Position",
                table: "Applications",
                newName: "Postion");
        }
    }
}
