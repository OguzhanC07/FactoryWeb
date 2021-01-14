using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace FactoryWebAPI.DataAccess.Migrations
{
    public partial class UpdatingOnDealerAndAppUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Dealers",
                maxLength: 60,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Dealers",
                maxLength: 10,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "BanCount",
                table: "AppUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                name: "BanEndTime",
                table: "AppUsers",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Dealers");

            migrationBuilder.DropColumn(
                name: "BanCount",
                table: "AppUsers");

            migrationBuilder.DropColumn(
                name: "BanEndTime",
                table: "AppUsers");
        }
    }
}
