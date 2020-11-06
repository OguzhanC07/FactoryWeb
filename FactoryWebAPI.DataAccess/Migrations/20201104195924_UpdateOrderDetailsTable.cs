using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryWebAPI.DataAccess.Migrations
{
    public partial class UpdateOrderDetailsTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId_DealerId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails",
                column: "ProductId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_OrderDetails_ProductId",
                table: "OrderDetails");

            migrationBuilder.CreateIndex(
                name: "IX_OrderDetails_ProductId_DealerId",
                table: "OrderDetails",
                columns: new[] { "ProductId", "DealerId" },
                unique: true);
        }
    }
}
