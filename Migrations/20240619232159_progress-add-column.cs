using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learndotnetfast_web_services.Migrations
{
    /// <inheritdoc />
    public partial class progressaddcolumn : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tutorials_progress_ProgressId",
                table: "tutorials");

            migrationBuilder.DropIndex(
                name: "IX_tutorials_ProgressId",
                table: "tutorials");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "tutorials");

            migrationBuilder.AddColumn<int>(
                name: "TutorialId",
                table: "progress",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TutorialId",
                table: "progress");

            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "tutorials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_tutorials_ProgressId",
                table: "tutorials",
                column: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_tutorials_progress_ProgressId",
                table: "tutorials",
                column: "ProgressId",
                principalTable: "progress",
                principalColumn: "Id");
        }
    }
}
