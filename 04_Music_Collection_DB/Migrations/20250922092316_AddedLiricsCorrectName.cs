using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace _04_Music_Collection_DB.Migrations
{
    /// <inheritdoc />
    public partial class AddedLiricsCorrectName : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "lyrics",
                table: "Tracks",
                newName: "Lyrics");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Lyrics",
                table: "Tracks",
                newName: "lyrics");
        }
    }
}
