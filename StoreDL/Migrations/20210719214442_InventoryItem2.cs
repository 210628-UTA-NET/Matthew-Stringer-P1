using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StoreDL.Migrations
{
    public partial class InventoryItem2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "StoreFrontId",
                table: "LineItems");

            migrationBuilder.CreateTable(
                name: "InventoryItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ProdId = table.Column<int>(type: "integer", nullable: true),
                    Quantity = table.Column<int>(type: "integer", nullable: false),
                    StoreFrontId = table.Column<int>(type: "integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InventoryItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_InventoryItems_Products_ProdId",
                        column: x => x.ProdId,
                        principalTable: "Products",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_InventoryItems_StoreFronts_StoreFrontId",
                        column: x => x.StoreFrontId,
                        principalTable: "StoreFronts",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_ProdId",
                table: "InventoryItems",
                column: "ProdId");

            migrationBuilder.CreateIndex(
                name: "IX_InventoryItems_StoreFrontId",
                table: "InventoryItems",
                column: "StoreFrontId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InventoryItems");

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "LineItems",
                type: "text",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<int>(
                name: "StoreFrontId",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_StoreFronts_StoreFrontId",
                table: "LineItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
