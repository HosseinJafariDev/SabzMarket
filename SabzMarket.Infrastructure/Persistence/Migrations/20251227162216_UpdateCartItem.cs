using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SabzMarket.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class UpdateCartItem : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Farmers_FarmerId1",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_FarmerId1",
                table: "CartItems");

            migrationBuilder.DropColumn(
                name: "FarmerId1",
                table: "CartItems");

            migrationBuilder.AlterColumn<long>(
                name: "FarmerId",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FarmerId",
                table: "CartItems",
                column: "FarmerId");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Farmers_FarmerId",
                table: "CartItems",
                column: "FarmerId",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CartItems_Farmers_FarmerId",
                table: "CartItems");

            migrationBuilder.DropIndex(
                name: "IX_CartItems_FarmerId",
                table: "CartItems");

            migrationBuilder.AlterColumn<int>(
                name: "FarmerId",
                table: "CartItems",
                type: "int",
                nullable: false,
                oldClrType: typeof(long),
                oldType: "bigint");

            migrationBuilder.AddColumn<long>(
                name: "FarmerId1",
                table: "CartItems",
                type: "bigint",
                nullable: false,
                defaultValue: 0L);

            migrationBuilder.CreateIndex(
                name: "IX_CartItems_FarmerId1",
                table: "CartItems",
                column: "FarmerId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CartItems_Farmers_FarmerId1",
                table: "CartItems",
                column: "FarmerId1",
                principalTable: "Farmers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
