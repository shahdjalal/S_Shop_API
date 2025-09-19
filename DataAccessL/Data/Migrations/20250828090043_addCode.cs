using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Shahd_DataAccessL.Data.Migrations
{
    /// <inheritdoc />
    public partial class addCode : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CodeResetPass",
                table: "Users",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ResetPasswordCodeExpiry",
                table: "Users",
                type: "datetime2",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CodeResetPass",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "ResetPasswordCodeExpiry",
                table: "Users");
        }
    }
}
