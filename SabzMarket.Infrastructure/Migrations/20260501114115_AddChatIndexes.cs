using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SabzMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class AddChatIndexes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Chat_ToUserId",
                table: "Chat",
                newName: "IX_Chats_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chat_FromUserId",
                table: "Chat",
                newName: "IX_Chats_FromUserId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameIndex(
                name: "IX_Chats_ToUserId",
                table: "Chat",
                newName: "IX_Chat_ToUserId");

            migrationBuilder.RenameIndex(
                name: "IX_Chats_FromUserId",
                table: "Chat",
                newName: "IX_Chat_FromUserId");
        }
    }
}
