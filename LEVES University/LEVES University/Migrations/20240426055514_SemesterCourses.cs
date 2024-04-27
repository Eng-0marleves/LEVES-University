using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class SemesterCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "SemesterCourses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    CourseId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemesterCourses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemesterCourses_CoursesCatalogues_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesCatalogues",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SemesterCourses_SemestersInfo_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "SemestersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCourses_CourseId",
                table: "SemesterCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCourses_SemesterId_CourseId",
                table: "SemesterCourses",
                columns: new[] { "SemesterId", "CourseId" },
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "SemesterCourses");
        }
    }
}
