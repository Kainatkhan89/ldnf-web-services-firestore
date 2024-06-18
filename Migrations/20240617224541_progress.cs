using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learndotnetfast_web_services.Migrations
{
    /// <inheritdoc />
    public partial class progress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ProgressId",
                table: "tutorials",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Progresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Progresses", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tutorials_ProgressId",
                table: "tutorials",
                column: "ProgressId");

            migrationBuilder.AddForeignKey(
                name: "FK_tutorials_Progresses_ProgressId",
                table: "tutorials",
                column: "ProgressId",
                principalTable: "Progresses",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_tutorials_Progresses_ProgressId",
                table: "tutorials");

            migrationBuilder.DropTable(
                name: "Progresses");

            migrationBuilder.DropIndex(
                name: "IX_tutorials_ProgressId",
                table: "tutorials");

            migrationBuilder.DropColumn(
                name: "ProgressId",
                table: "tutorials");
        }
    }
}
