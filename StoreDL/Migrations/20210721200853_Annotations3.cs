using Microsoft.EntityFrameworkCore.Migrations;

namespace StoreDL.Migrations
{
    public partial class Annotations3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_Order",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_Order",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "LineItems");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_OrderId",
                table: "LineItems",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_OrderId",
                table: "LineItems",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_OrderId",
                table: "LineItems");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_OrderId",
                table: "LineItems");

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Order",
                table: "LineItems",
                column: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_Order",
                table: "LineItems",
                column: "Order",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
