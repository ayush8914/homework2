using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework2.Migrations
{
    public partial class submittedAssignmentTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SubmittedAssignments",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentID = table.Column<int>(type: "int", nullable: true),
                    AppUserID = table.Column<string>(type: "nvarchar(450)", nullable: true),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Files = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SubmittedAssignments", x => x.ID);
                    table.ForeignKey(
                        name: "FK_SubmittedAssignments_AspNetUsers_AppUserID",
                        column: x => x.AppUserID,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SubmittedAssignments_Assignments_AssignmentID",
                        column: x => x.AssignmentID,
                        principalTable: "Assignments",
                        principalColumn: "ID");
                });

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAssignments_AppUserID",
                table: "SubmittedAssignments",
                column: "AppUserID");

            migrationBuilder.CreateIndex(
                name: "IX_SubmittedAssignments_AssignmentID",
                table: "SubmittedAssignments",
                column: "AssignmentID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SubmittedAssignments");
        }
    }
}
