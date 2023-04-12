using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesaQuestAPI.Migrations
{
    public partial class QuestTablesAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "QuestsCompleted",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "QuestsComposed",
                table: "users",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestsCompleted",
                table: "users");

            migrationBuilder.DropColumn(
                name: "QuestsComposed",
                table: "users");
        }
    }
}
