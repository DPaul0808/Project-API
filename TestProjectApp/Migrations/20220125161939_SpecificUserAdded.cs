using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProjectApp.Migrations
{
    public partial class SpecificUserAdded : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "AspNetUsers",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "AspNetUsers");
        }
    }
}
