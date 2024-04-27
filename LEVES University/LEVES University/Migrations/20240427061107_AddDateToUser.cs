using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class AddDateToUser : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfo_Users_StudentId",
                table: "StudentInfo");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfo_StudentId",
                table: "StudentInfo");

            migrationBuilder.AddColumn<DateTime>(
                name: "DateOfBirth",
                table: "Users",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentInfo",
                type: "nvarchar(450)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(450)");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_StudentId",
                table: "StudentInfo",
                column: "StudentId",
                unique: true,
                filter: "[StudentId] IS NOT NULL");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfo_Users_StudentId",
                table: "StudentInfo",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentInfo_Users_StudentId",
                table: "StudentInfo");

            migrationBuilder.DropIndex(
                name: "IX_StudentInfo_StudentId",
                table: "StudentInfo");

            migrationBuilder.DropColumn(
                name: "DateOfBirth",
                table: "Users");

            migrationBuilder.AlterColumn<string>(
                name: "StudentId",
                table: "StudentInfo",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "",
                oldClrType: typeof(string),
                oldType: "nvarchar(450)",
                oldNullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_StudentId",
                table: "StudentInfo",
                column: "StudentId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentInfo_Users_StudentId",
                table: "StudentInfo",
                column: "StudentId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
