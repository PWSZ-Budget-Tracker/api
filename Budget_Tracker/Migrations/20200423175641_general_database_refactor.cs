using Microsoft.EntityFrameworkCore.Migrations;

namespace Budget_Tracker.Migrations
{
    public partial class general_database_refactor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Goals",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Goals");
        }
    }
}
