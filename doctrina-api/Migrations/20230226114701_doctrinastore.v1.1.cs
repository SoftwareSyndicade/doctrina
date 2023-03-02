using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doctrineapi.Migrations
{
    /// <inheritdoc />
    public partial class doctrinastorev11 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "MEETING_LINK",
                table: "ASSISTANCE_REQUEST",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "SETUP_MEETING",
                table: "ASSISTANCE_REQUEST",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MEETING_LINK",
                table: "ASSISTANCE_REQUEST");

            migrationBuilder.DropColumn(
                name: "SETUP_MEETING",
                table: "ASSISTANCE_REQUEST");
        }
    }
}
