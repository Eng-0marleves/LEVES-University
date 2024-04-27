using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class uniqueAreaTitle : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_AreasOfStudy_StudyTitle",
                table: "AreasOfStudy",
                column: "StudyTitle",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_AreasOfStudy_StudyTitle",
                table: "AreasOfStudy");
        }
    }
}
