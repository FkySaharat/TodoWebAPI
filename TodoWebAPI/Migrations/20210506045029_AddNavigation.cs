using Microsoft.EntityFrameworkCore.Migrations;

namespace TodoWebAPI.Migrations
{
    public partial class AddNavigation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "priorityType",
                table: "TodoItem",
                newName: "priorityTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_TodoItem_priorityTypeId",
                table: "TodoItem",
                column: "priorityTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItem_TodoPriorityType_priorityTypeId",
                table: "TodoItem",
                column: "priorityTypeId",
                principalTable: "TodoPriorityType",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItem_TodoPriorityType_priorityTypeId",
                table: "TodoItem");

            migrationBuilder.DropIndex(
                name: "IX_TodoItem_priorityTypeId",
                table: "TodoItem");

            migrationBuilder.RenameColumn(
                name: "priorityTypeId",
                table: "TodoItem",
                newName: "priorityType");
        }
    }
}
