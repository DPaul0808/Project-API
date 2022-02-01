using Microsoft.EntityFrameworkCore.Migrations;

namespace TestProjectApp.Migrations
{
    public partial class ConnectedObjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Components_Computers_ComputerId",
                table: "Components");

            migrationBuilder.DropForeignKey(
                name: "FK_Features_Components_ComponentId",
                table: "Features");

            migrationBuilder.DropIndex(
                name: "IX_Components_ComputerId",
                table: "Components");

            migrationBuilder.DropColumn(
                name: "ComputerId",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "Features",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Category",
                table: "Components",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ComputerComponent",
                columns: table => new
                {
                    ComputerId = table.Column<int>(nullable: false),
                    ComponentId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComputerComponent", x => new { x.ComputerId, x.ComponentId });
                    table.ForeignKey(
                        name: "FK_ComputerComponent_Components_ComponentId",
                        column: x => x.ComponentId,
                        principalTable: "Components",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ComputerComponent_Computers_ComputerId",
                        column: x => x.ComputerId,
                        principalTable: "Computers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ComputerComponent_ComponentId",
                table: "ComputerComponent",
                column: "ComponentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Components_ComponentId",
                table: "Features",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Features_Components_ComponentId",
                table: "Features");

            migrationBuilder.DropTable(
                name: "ComputerComponent");

            migrationBuilder.DropColumn(
                name: "Category",
                table: "Components");

            migrationBuilder.AlterColumn<int>(
                name: "ComponentId",
                table: "Features",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "ComputerId",
                table: "Components",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Components_ComputerId",
                table: "Components",
                column: "ComputerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Components_Computers_ComputerId",
                table: "Components",
                column: "ComputerId",
                principalTable: "Computers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Features_Components_ComponentId",
                table: "Features",
                column: "ComponentId",
                principalTable: "Components",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
