using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doctrineapi.Migrations
{
    /// <inheritdoc />
    public partial class doctrinadbv1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ACCOUNT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    USERNAME = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false),
                    PASSWORDHASH = table.Column<string>(name: "PASSWORD_HASH", type: "nvarchar(max)", nullable: false),
                    SALT = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    FIRSTNAME = table.Column<string>(name: "FIRST_NAME", type: "nvarchar(max)", nullable: false),
                    MIDDELNAME = table.Column<string>(name: "MIDDEL_NAME", type: "nvarchar(max)", nullable: true),
                    LASTNAME = table.Column<string>(name: "LAST_NAME", type: "nvarchar(max)", nullable: false),
                    PHONENUMBER = table.Column<string>(name: "PHONE_NUMBER", type: "nvarchar(max)", nullable: false),
                    EMAIL = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNT");
        }
    }
}
