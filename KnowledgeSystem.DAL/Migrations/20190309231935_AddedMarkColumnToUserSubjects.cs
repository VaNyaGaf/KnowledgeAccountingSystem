using Microsoft.EntityFrameworkCore.Migrations;

namespace KnowledgeSystem.DAL.Migrations
{
    public partial class AddedMarkColumnToUserSubjects : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Mark",
                table: "UserSubjects",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Mark",
                table: "UserSubjects");
        }
    }
}
