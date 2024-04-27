using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class HandleSemesterInfo : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CoursesSchedules_SemestersInfo_AreaOfStudyId",
                table: "CoursesSchedules");

            migrationBuilder.DropForeignKey(
                name: "FK_SemestersInfo_AreasOfStudy_AreaOfStudyId",
                table: "SemestersInfo");

            migrationBuilder.DropIndex(
                name: "IX_SemestersInfo_AreaOfStudyId",
                table: "SemestersInfo");

            migrationBuilder.DropIndex(
                name: "IX_CoursesSchedules_AreaOfStudyId",
                table: "CoursesSchedules");

            migrationBuilder.DropColumn(
                name: "AreaOfStudyId",
                table: "SemestersInfo");

            migrationBuilder.DropColumn(
                name: "AreaOfStudyId",
                table: "CoursesSchedules");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AreaOfStudyId",
                table: "SemestersInfo",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "AreaOfStudyId",
                table: "CoursesSchedules",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemestersInfo_AreaOfStudyId",
                table: "SemestersInfo",
                column: "AreaOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSchedules_AreaOfStudyId",
                table: "CoursesSchedules",
                column: "AreaOfStudyId");

            migrationBuilder.AddForeignKey(
                name: "FK_CoursesSchedules_SemestersInfo_AreaOfStudyId",
                table: "CoursesSchedules",
                column: "AreaOfStudyId",
                principalTable: "SemestersInfo",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemestersInfo_AreasOfStudy_AreaOfStudyId",
                table: "SemestersInfo",
                column: "AreaOfStudyId",
                principalTable: "AreasOfStudy",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
