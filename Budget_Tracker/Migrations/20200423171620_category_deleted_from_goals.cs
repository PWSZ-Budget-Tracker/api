using Microsoft.EntityFrameworkCore.Migrations;

namespace Budget_Tracker.Migrations
{
    public partial class category_deleted_from_goals : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Categories_CategoryId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Goals",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Categories_CategoryId",
                table: "Goals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Goals_Categories_CategoryId",
                table: "Goals");

            migrationBuilder.AlterColumn<int>(
                name: "CategoryId",
                table: "Goals",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Goals_Categories_CategoryId",
                table: "Goals",
                column: "CategoryId",
                principalTable: "Categories",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
