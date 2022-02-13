using Microsoft.EntityFrameworkCore.Migrations;

namespace AgileManagement.Persistence.EF.migrations.projectdb
{
    public partial class AddSprint1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SprintNo",
                table: "Sprint",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                name: "isActive",
                table: "Sprint",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SprintNo",
                table: "Sprint");

            migrationBuilder.DropColumn(
                name: "isActive",
                table: "Sprint");
        }
    }
}
