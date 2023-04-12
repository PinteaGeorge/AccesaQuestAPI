using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace AccesaQuestAPI.Migrations
{
    public partial class QuestTablesAdded1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CommonQuests",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    QuestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestXp = table.Column<int>(type: "int", nullable: false),
                    QuestPoints = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CommonQuests", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CompletedQuestsFromUsers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    QuestName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    QuestBody = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CompletedUserId = table.Column<int>(type: "int", nullable: false),
                    QuestCompleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CompletedQuestsFromUsers", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CommonQuests");

            migrationBuilder.DropTable(
                name: "CompletedQuestsFromUsers");
        }
    }
}
