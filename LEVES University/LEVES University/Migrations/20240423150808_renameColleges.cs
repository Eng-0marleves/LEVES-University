using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class renameColleges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfStudy_colleges_CollegeId",
                table: "AreasOfStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_colleges",
                table: "colleges");

            migrationBuilder.RenameTable(
                name: "colleges",
                newName: "Colleges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfStudy_Colleges_CollegeId",
                table: "AreasOfStudy",
                column: "CollegeId",
                principalTable: "Colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AreasOfStudy_Colleges_CollegeId",
                table: "AreasOfStudy");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Colleges",
                table: "Colleges");

            migrationBuilder.RenameTable(
                name: "Colleges",
                newName: "colleges");

            migrationBuilder.AddPrimaryKey(
                name: "PK_colleges",
                table: "colleges",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_AreasOfStudy_colleges_CollegeId",
                table: "AreasOfStudy",
                column: "CollegeId",
                principalTable: "colleges",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
