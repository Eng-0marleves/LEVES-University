using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class AddIsChildCourseOpenToPrerqeuisits : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsChildCourseOpen",
                table: "Prerequisites",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsChildCourseOpen",
                table: "Prerequisites");
        }
    }
}
