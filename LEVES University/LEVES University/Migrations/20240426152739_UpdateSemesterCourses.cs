using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class UpdateSemesterCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourses_SemestersInfo_SemesterId",
                table: "SemesterCourses");

            migrationBuilder.DropIndex(
                name: "IX_SemesterCourses_SemesterId_CourseId",
                table: "SemesterCourses");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "SemesterCourses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SemesterId",
                table: "SemesterCourses",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_SemesterCourses_SemesterId_CourseId",
                table: "SemesterCourses",
                columns: new[] { "SemesterId", "CourseId" },
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourses_SemestersInfo_SemesterId",
                table: "SemesterCourses",
                column: "SemesterId",
                principalTable: "SemestersInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
