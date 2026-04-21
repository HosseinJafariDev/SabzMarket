using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SabzMarket.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class createChatTable : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ChatId",
                table: "User",
                type: "bigint",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsDeleted",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsFile",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsRead",
                table: "Chat",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<DateTime>(
                name: "SentAt",
                table: "Chat",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.CreateIndex(
                name: "IX_User_ChatId",
                table: "User",
                column: "ChatId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Chat_ChatId",
                table: "User",
                column: "ChatId",
                principalTable: "Chat",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Chat_ChatId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ChatId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ChatId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "IsDeleted",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "IsFile",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "IsRead",
                table: "Chat");

            migrationBuilder.DropColumn(
                name: "SentAt",
                table: "Chat");
        }
    }
}
