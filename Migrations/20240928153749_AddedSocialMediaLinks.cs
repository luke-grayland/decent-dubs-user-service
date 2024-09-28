using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DecentDubs.UserService.Migrations
{
    /// <inheritdoc />
    public partial class AddedSocialMediaLinks : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SocialMediaLinks",
                columns: table => new
                {
                    WalletId = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    SocialMediaTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SocialMediaLinks", x => new { x.WalletId, x.SocialMediaTypeId });
                    table.ForeignKey(
                        name: "FK_SocialMediaLinks_SocialMediaTypes_SocialMediaTypeId",
                        column: x => x.SocialMediaTypeId,
                        principalTable: "SocialMediaTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SocialMediaLinks_Users_WalletId",
                        column: x => x.WalletId,
                        principalTable: "Users",
                        principalColumn: "WalletId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SocialMediaLinks_SocialMediaTypeId",
                table: "SocialMediaLinks",
                column: "SocialMediaTypeId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SocialMediaLinks");
        }
    }
}
