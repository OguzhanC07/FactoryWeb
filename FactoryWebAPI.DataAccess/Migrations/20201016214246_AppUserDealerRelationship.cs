using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryWebAPI.DataAccess.Migrations
{
    public partial class AppUserDealerRelationship : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_AppUserId",
                table: "Dealers");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_AppUserId",
                table: "Dealers",
                column: "AppUserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Dealers_AppUserId",
                table: "Dealers");

            migrationBuilder.CreateIndex(
                name: "IX_Dealers_AppUserId",
                table: "Dealers",
                column: "AppUserId",
                unique: true);
        }
    }
}
