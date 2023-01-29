using System;
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
                    IMAGE = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ACCOUNT", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "ASSISTANCE_REQUEST",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    CATEGORY = table.Column<int>(type: "int", nullable: false),
                    ISRECURRING = table.Column<bool>(name: "IS_RECURRING", type: "bit", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TUTOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MEETINGLINK = table.Column<string>(name: "MEETING_LINK", type: "nvarchar(max)", nullable: false),
                    DEADLINE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    COMPLETED = table.Column<bool>(type: "bit", nullable: false),
                    PAID = table.Column<bool>(type: "bit", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false),
                    CREATEDBY = table.Column<string>(name: "CREATED_BY", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSISTANCE_REQUEST", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ACCOUNT");

            migrationBuilder.DropTable(
                name: "ASSISTANCE_REQUEST");
        }
    }
}
