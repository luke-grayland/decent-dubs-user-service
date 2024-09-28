using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecentDubs.UserService.Migrations
{
    /// <inheritdoc />
    public partial class AddedForeignKeyBetweenUserSessionAndSessionId : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateOnly>(
                name: "Created",
                table: "Users",
                type: "date",
                nullable: true,
                oldClrType: typeof(DateTime),
                oldType: "datetime2",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserSessions_WalletId",
                table: "UserSessions",
                column: "WalletId");

            migrationBuilder.AddForeignKey(
                name: "FK_UserSessions_Users_WalletId",
                table: "UserSessions",
                column: "WalletId",
                principalTable: "Users",
                principalColumn: "WalletId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_UserSessions_Users_WalletId",
                table: "UserSessions");

            migrationBuilder.DropIndex(
                name: "IX_UserSessions_WalletId",
                table: "UserSessions");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Created",
                table: "Users",
                type: "datetime2",
                nullable: true,
                oldClrType: typeof(DateOnly),
                oldType: "date",
                oldNullable: true);
        }
    }
}
