using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learndotnetfast_web_services.Migrations
{
    /// <inheritdoc />
    public partial class progresstableupdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tutorials_Progresses_ProgressId",
                table: "tutorials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses");

            migrationBuilder.RenameTable(
                name: "Progresses",
                newName: "progress");

            migrationBuilder.AddPrimaryKey(
                name: "PK_progress",
                table: "progress",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tutorials_progress_ProgressId",
                table: "tutorials",
                column: "ProgressId",
                principalTable: "progress",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tutorials_progress_ProgressId",
                table: "tutorials");

            migrationBuilder.DropPrimaryKey(
                name: "PK_progress",
                table: "progress");

            migrationBuilder.RenameTable(
                name: "progress",
                newName: "Progresses");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Progresses",
                table: "Progresses",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_tutorials_Progresses_ProgressId",
                table: "tutorials",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "Id");
        }
    }
}
