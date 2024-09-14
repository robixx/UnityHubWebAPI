using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace UnityHubWebAPI.Migrations
{
    /// <inheritdoc />
    public partial class createtableint : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "LoginUser",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Username = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PasswordSalt = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CREATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UPDATE_BY = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UPDATE_DATE = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_LoginUser", x => x.UserId);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "LoginUser");
        }
    }
}
