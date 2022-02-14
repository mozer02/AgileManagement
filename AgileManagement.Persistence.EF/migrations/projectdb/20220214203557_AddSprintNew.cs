using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileManagement.Persistence.EF.migrations.projectdb
{
    public partial class AddSprintNew : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintNo",
                table: "Sprint");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintNo",
                table: "Sprint",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
