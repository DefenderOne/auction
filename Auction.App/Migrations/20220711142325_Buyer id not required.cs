using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Auction.App.Migrations
{
    public partial class Buyeridnotrequired : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_lots_members_buyer_id",
                table: "lots");

            migrationBuilder.AddForeignKey(
                name: "fk_lots_members_buyer_id",
                table: "lots",
                column: "buyer_id",
                principalTable: "members",
                principalColumn: "id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_lots_members_buyer_id",
                table: "lots");

            migrationBuilder.AddForeignKey(
                name: "fk_lots_members_buyer_id",
                table: "lots",
                column: "buyer_id",
                principalTable: "members",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
