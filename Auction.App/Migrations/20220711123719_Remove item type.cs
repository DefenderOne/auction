using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auction.App.Migrations
{
    public partial class Removeitemtype : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "fk_items_item_types_type_id",
                table: "items");

            migrationBuilder.DropTable(
                name: "item_types");

            migrationBuilder.DropIndex(
                name: "ix_items_type_id",
                table: "items");

            migrationBuilder.DropColumn(
                name: "type_id",
                table: "items");

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "items",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "type",
                table: "items");

            migrationBuilder.AddColumn<int>(
                name: "type_id",
                table: "items",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "item_types",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_item_types", x => x.id);
                });

            migrationBuilder.CreateIndex(
                name: "ix_items_type_id",
                table: "items",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_item_types_name",
                table: "item_types",
                column: "name",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "fk_items_item_types_type_id",
                table: "items",
                column: "type_id",
                principalTable: "item_types",
                principalColumn: "id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
