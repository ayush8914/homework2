using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Homework2.Migrations
{
    public partial class appusermodify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "temp",
                table: "AspNetUsers",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "temp",
                table: "AspNetUsers");
        }
    }
}
