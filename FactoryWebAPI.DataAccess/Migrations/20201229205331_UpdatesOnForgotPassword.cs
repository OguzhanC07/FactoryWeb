using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryWebAPI.DataAccess.Migrations
{
    public partial class UpdatesOnForgotPassword : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "ForgotPasswords",
                nullable: false,
                defaultValue: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "isActive",
                table: "ForgotPasswords");
        }
    }
}
