using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace learndotnetfast_web_services.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "course_modules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false),
                    Color = table.Column<string>(type: "nvarchar(25)", maxLength: 25, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_course_modules", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "tutorials",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ModuleId = table.Column<int>(type: "int", nullable: false),
                    Number = table.Column<int>(type: "int", nullable: false),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    duration_seconds = table.Column<int>(type: "int", nullable: false),
                    video_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    starter_code_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    finished_code_url = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tutorials", x => x.Id);
                    table.ForeignKey(
                        name: "FK_tutorials_course_modules_ModuleId",
                        column: x => x.ModuleId,
                        principalTable: "course_modules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_tutorials_ModuleId",
                table: "tutorials",
                column: "ModuleId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "tutorials");

            migrationBuilder.DropTable(
                name: "course_modules");
        }
    }
}
