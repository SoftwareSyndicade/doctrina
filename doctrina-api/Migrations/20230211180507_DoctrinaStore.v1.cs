using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace doctrineapi.Migrations
{
    /// <inheritdoc />
    public partial class DoctrinaStorev1 : Migration
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
                    ACCOUNTTYPE = table.Column<int>(name: "ACCOUNT_TYPE", type: "int", nullable: false),
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
                    EDUCATIONLEVEL = table.Column<int>(name: "EDUCATION_LEVEL", type: "int", nullable: false),
                    DETAILS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false),
                    CREATEDBY = table.Column<string>(name: "CREATED_BY", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSISTANCE_REQUEST", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "STUDENT",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACCOUNTID = table.Column<string>(name: "ACCOUNT_ID", type: "nvarchar(450)", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_STUDENT", x => x.ID);
                    table.ForeignKey(
                        name: "FK_STUDENT_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNTID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "TUTOR",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ACCOUNTID = table.Column<string>(name: "ACCOUNT_ID", type: "nvarchar(450)", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TUTOR", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TUTOR_ACCOUNT_ACCOUNT_ID",
                        column: x => x.ACCOUNTID,
                        principalTable: "ACCOUNT",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ASSISTANCE_PROPOSALS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REQUESTID = table.Column<string>(name: "REQUEST_ID", type: "nvarchar(450)", nullable: false),
                    TUTOR = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ACTIVE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HOURS = table.Column<int>(type: "int", nullable: false),
                    COST = table.Column<double>(type: "float", nullable: false),
                    PERHOURRATE = table.Column<double>(name: "PERHOUR_RATE", type: "float", nullable: false),
                    DISCOUNT = table.Column<double>(type: "float", nullable: false),
                    AVAILABILITY = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false),
                    CREATEDBY = table.Column<string>(name: "CREATED_BY", type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ASSISTANCE_PROPOSALS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ASSISTANCE_PROPOSALS_ASSISTANCE_REQUEST_REQUEST_ID",
                        column: x => x.REQUESTID,
                        principalTable: "ASSISTANCE_REQUEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ATTACHMENTS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    REQUESTID = table.Column<string>(name: "REQUEST_ID", type: "nvarchar(450)", nullable: false),
                    NAME = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CONTENT = table.Column<byte[]>(type: "varbinary(max)", nullable: false),
                    MIMETYPE = table.Column<string>(name: "MIME_TYPE", type: "nvarchar(max)", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ATTACHMENTS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ATTACHMENTS_ASSISTANCE_REQUEST_REQUEST_ID",
                        column: x => x.REQUESTID,
                        principalTable: "ASSISTANCE_REQUEST",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "QUALIFICATIONS",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    TUTORID = table.Column<string>(name: "TUTOR_ID", type: "nvarchar(450)", nullable: false),
                    QUALIFICATIONTYPE = table.Column<int>(name: "QUALIFICATION_TYPE", type: "int", nullable: false),
                    INSTITUTION = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TITLE = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FIELD = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    NUMBEROFYEARS = table.Column<int>(name: "NUMBER_OF_YEARS", type: "int", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_QUALIFICATIONS", x => x.ID);
                    table.ForeignKey(
                        name: "FK_QUALIFICATIONS_TUTOR_TUTOR_ID",
                        column: x => x.TUTORID,
                        principalTable: "TUTOR",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "DEGREE",
                columns: table => new
                {
                    ID = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    QUALIFICATIONID = table.Column<string>(name: "QUALIFICATION_ID", type: "nvarchar(450)", nullable: false),
                    EDUCATIONLEVEL = table.Column<int>(name: "EDUCATION_LEVEL", type: "int", nullable: false),
                    GRADES = table.Column<int>(type: "int", nullable: false),
                    CREATEDON = table.Column<DateTime>(name: "CREATED_ON", type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DEGREE", x => x.ID);
                    table.ForeignKey(
                        name: "FK_DEGREE_QUALIFICATIONS_QUALIFICATION_ID",
                        column: x => x.QUALIFICATIONID,
                        principalTable: "QUALIFICATIONS",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ASSISTANCE_PROPOSALS_REQUEST_ID",
                table: "ASSISTANCE_PROPOSALS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_ATTACHMENTS_REQUEST_ID",
                table: "ATTACHMENTS",
                column: "REQUEST_ID");

            migrationBuilder.CreateIndex(
                name: "IX_DEGREE_QUALIFICATION_ID",
                table: "DEGREE",
                column: "QUALIFICATION_ID");

            migrationBuilder.CreateIndex(
                name: "IX_QUALIFICATIONS_TUTOR_ID",
                table: "QUALIFICATIONS",
                column: "TUTOR_ID");

            migrationBuilder.CreateIndex(
                name: "IX_STUDENT_ACCOUNT_ID",
                table: "STUDENT",
                column: "ACCOUNT_ID");

            migrationBuilder.CreateIndex(
                name: "IX_TUTOR_ACCOUNT_ID",
                table: "TUTOR",
                column: "ACCOUNT_ID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ASSISTANCE_PROPOSALS");

            migrationBuilder.DropTable(
                name: "ATTACHMENTS");

            migrationBuilder.DropTable(
                name: "DEGREE");

            migrationBuilder.DropTable(
                name: "STUDENT");

            migrationBuilder.DropTable(
                name: "ASSISTANCE_REQUEST");

            migrationBuilder.DropTable(
                name: "QUALIFICATIONS");

            migrationBuilder.DropTable(
                name: "TUTOR");

            migrationBuilder.DropTable(
                name: "ACCOUNT");
        }
    }
}
