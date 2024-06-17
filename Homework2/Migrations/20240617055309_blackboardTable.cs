using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework2.Migrations
{
    public partial class blackboardTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BlackBoards",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClassroomId = table.Column<int>(type: "int", nullable: true),
                    AppUserId = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    content = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FilesPaths = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BlackBoards", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BlackBoards_ClassroomUsers_ClassroomId_AppUserId",
                        columns: x => new { x.ClassroomId, x.AppUserId },
                        principalTable: "ClassroomUsers",
                        principalColumns: new[] { "ClassroomId", "AppUserId" },
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BlackBoards_ClassroomId_AppUserId",
                table: "BlackBoards",
                columns: new[] { "ClassroomId", "AppUserId" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BlackBoards");
        }
    }
}
