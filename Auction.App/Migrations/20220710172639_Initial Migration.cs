using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

#nullable disable

namespace Auction.App.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "auctions",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    date = table.Column<DateOnly>(type: "date", nullable: false),
                    address = table.Column<string>(type: "text", nullable: true),
                    description = table.Column<string>(type: "text", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_auctions", x => x.id);
                });

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

            migrationBuilder.CreateTable(
                name: "members",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    name = table.Column<string>(type: "text", nullable: false),
                    phone_number = table.Column<string>(type: "text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_members", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "items",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    owner_id = table.Column<int>(type: "integer", nullable: false),
                    name = table.Column<string>(type: "text", nullable: false),
                    type_id = table.Column<int>(type: "integer", nullable: false),
                    received_at = table.Column<DateOnly>(type: "date", nullable: false),
                    is_sold = table.Column<bool>(type: "boolean", nullable: false, defaultValue: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_items", x => x.id);
                    table.ForeignKey(
                        name: "fk_items_item_types_type_id",
                        column: x => x.type_id,
                        principalTable: "item_types",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_items_members_owner_id",
                        column: x => x.owner_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "lots",
                columns: table => new
                {
                    id = table.Column<int>(type: "integer", nullable: false),
                    auction_id = table.Column<int>(type: "integer", nullable: false),
                    item_id = table.Column<int>(type: "integer", nullable: false),
                    start_price = table.Column<decimal>(type: "numeric", nullable: false),
                    end_price = table.Column<decimal>(type: "numeric", nullable: false),
                    buyer_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_lots", x => new { x.id, x.auction_id });
                    table.ForeignKey(
                        name: "fk_lots_auctions_auction_id",
                        column: x => x.auction_id,
                        principalTable: "auctions",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lots_items_item_id",
                        column: x => x.item_id,
                        principalTable: "items",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_lots_members_buyer_id",
                        column: x => x.buyer_id,
                        principalTable: "members",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_item_types_name",
                table: "item_types",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_items_name",
                table: "items",
                column: "name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "ix_items_owner_id",
                table: "items",
                column: "owner_id");

            migrationBuilder.CreateIndex(
                name: "ix_items_type_id",
                table: "items",
                column: "type_id");

            migrationBuilder.CreateIndex(
                name: "ix_lots_auction_id",
                table: "lots",
                column: "auction_id");

            migrationBuilder.CreateIndex(
                name: "ix_lots_buyer_id",
                table: "lots",
                column: "buyer_id");

            migrationBuilder.CreateIndex(
                name: "ix_lots_item_id",
                table: "lots",
                column: "item_id",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "lots");

            migrationBuilder.DropTable(
                name: "auctions");

            migrationBuilder.DropTable(
                name: "items");

            migrationBuilder.DropTable(
                name: "item_types");

            migrationBuilder.DropTable(
                name: "members");
        }
    }
}
