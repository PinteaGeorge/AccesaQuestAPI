using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesaQuestAPI.Migrations
{
    public partial class UpdatedUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Level",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Points",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Xp",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Level",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Points",
                table: "users");

            migrationBuilder.DropColumn(
                name: "Xp",
                table: "users");
        }
    }
}
