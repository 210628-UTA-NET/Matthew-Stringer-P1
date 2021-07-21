using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace StoreDL.Migrations
{
    public partial class Annotations : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_StoreFronts_StoreFrontId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Orders_OrderId",
                table: "Orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_OrderId",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "Orders");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "StoreFronts",
                newName: "StoreFrontId");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Order",
                table: "LineItems",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "LineItems",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "InventoryItems",
                type: "integer",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "integer",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_LineItems_Order",
                table: "LineItems",
                column: "Order");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_StoreFronts_StoreFrontId",
                table: "InventoryItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "StoreFrontId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_LineItems_Orders_Order",
                table: "LineItems",
                column: "Order",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_InventoryItems_StoreFronts_StoreFrontId",
                table: "InventoryItems");

            migrationBuilder.DropForeignKey(
                name: "FK_LineItems_Orders_Order",
                table: "LineItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Orders",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_LineItems_Order",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "Order",
                table: "LineItems");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "LineItems");

            migrationBuilder.RenameColumn(
                name: "StoreFrontId",
                table: "StoreFronts",
                newName: "Id");

            migrationBuilder.AlterColumn<int>(
                name: "OrderId",
                table: "Orders",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer")
                .OldAnnotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AddColumn<int>(
                name: "Id",
                table: "Orders",
                type: "integer",
                nullable: false,
                defaultValue: 0)
                .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn);

            migrationBuilder.AlterColumn<int>(
                name: "StoreFrontId",
                table: "InventoryItems",
                type: "integer",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "integer");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Orders",
                table: "Orders",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_OrderId",
                table: "Orders",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_InventoryItems_StoreFronts_StoreFrontId",
                table: "InventoryItems",
                column: "StoreFrontId",
                principalTable: "StoreFronts",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Orders_OrderId",
                table: "Orders",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
