using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace LEVES_University.Migrations
{
    /// <inheritdoc />
    public partial class Init : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Buildings",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Buildings", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "colleges",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_colleges", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CoursesCatalogues",
                columns: table => new
                {
                    CourseNumber = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    CourseTitle = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseDescription = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    CreditHours = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesCatalogues", x => x.CourseNumber);
                });

            migrationBuilder.CreateTable(
                name: "Grades",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Grades", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "JopInformation",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Requirements = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    MinPay = table.Column<double>(type: "float", nullable: false),
                    MaxPay = table.Column<double>(type: "float", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_JopInformation", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Classrooms",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BuildingId = table.Column<int>(type: "int", nullable: false),
                    RoomCode = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    MaxSeating = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Classrooms", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Classrooms_Buildings_BuildingId",
                        column: x => x.BuildingId,
                        principalTable: "Buildings",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AreasOfStudy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudyTitle = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CollegeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreasOfStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AreasOfStudy_colleges_CollegeId",
                        column: x => x.CollegeId,
                        principalTable: "colleges",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Prerequisites",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ParentCourseId = table.Column<int>(type: "int", nullable: false),
                    ChildCourseId = table.Column<int>(type: "int", nullable: false),
                    CompositeKey = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Prerequisites", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Prerequisites_CoursesCatalogues_ChildCourseId",
                        column: x => x.ChildCourseId,
                        principalTable: "CoursesCatalogues",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Prerequisites_CoursesCatalogues_ParentCourseId",
                        column: x => x.ParentCourseId,
                        principalTable: "CoursesCatalogues",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    NTID = table.Column<long>(type: "bigint", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Users_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseAreaOfStudy",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseCatalogueId = table.Column<int>(type: "int", nullable: false),
                    AreaOfStudyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseAreaOfStudy", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseAreaOfStudy_AreasOfStudy_AreaOfStudyId",
                        column: x => x.AreaOfStudyId,
                        principalTable: "AreasOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseAreaOfStudy_CoursesCatalogues_CourseCatalogueId",
                        column: x => x.CourseCatalogueId,
                        principalTable: "CoursesCatalogues",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SemestersInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Year = table.Column<int>(type: "int", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentStartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EnrollmentEndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AreaOfStudyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SemestersInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SemestersInfo_AreasOfStudy_AreaOfStudyId",
                        column: x => x.AreaOfStudyId,
                        principalTable: "AreasOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    City = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street1 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Zip = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Addresses_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    YearlyPay = table.Column<double>(type: "float", nullable: false),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    JopInformationId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_JopInformation_JopInformationId",
                        column: x => x.JopInformationId,
                        principalTable: "JopInformation",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeInfo_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentInfo",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Grade = table.Column<int>(type: "int", nullable: false),
                    GPA = table.Column<double>(type: "float", nullable: false),
                    StudentId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    AreaOfStudyId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentInfo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentInfo_AreasOfStudy_AreaOfStudyId",
                        column: x => x.AreaOfStudyId,
                        principalTable: "AreasOfStudy",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_StudentInfo_Users_StudentId",
                        column: x => x.StudentId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsersProfilePicture",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ImageName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ImagePath = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsersProfilePicture", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsersProfilePicture_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CoursesSchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseNumber = table.Column<int>(type: "int", nullable: false),
                    SemesterId = table.Column<int>(type: "int", nullable: false),
                    NumberOfSeats = table.Column<int>(type: "int", nullable: false),
                    ClassRoomId = table.Column<int>(type: "int", nullable: false),
                    AreaOfStudyId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CoursesSchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CoursesSchedules_Classrooms_ClassRoomId",
                        column: x => x.ClassRoomId,
                        principalTable: "Classrooms",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesSchedules_CoursesCatalogues_CourseNumber",
                        column: x => x.CourseNumber,
                        principalTable: "CoursesCatalogues",
                        principalColumn: "CourseNumber",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CoursesSchedules_SemestersInfo_AreaOfStudyId",
                        column: x => x.AreaOfStudyId,
                        principalTable: "SemestersInfo",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_CoursesSchedules_SemestersInfo_SemesterId",
                        column: x => x.SemesterId,
                        principalTable: "SemestersInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "courseDailySchedules",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseId = table.Column<int>(type: "int", nullable: false),
                    DoctorId = table.Column<int>(type: "int", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StartTime = table.Column<TimeSpan>(type: "time", nullable: false),
                    EndTime = table.Column<TimeSpan>(type: "time", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_courseDailySchedules", x => x.Id);
                    table.ForeignKey(
                        name: "FK_courseDailySchedules_CoursesSchedules_CourseId",
                        column: x => x.CourseId,
                        principalTable: "CoursesSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_courseDailySchedules_EmployeeInfo_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "EmployeeInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollments",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CourseEnrollments_CoursesSchedules_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CoursesSchedules",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollmentGrades",
                columns: table => new
                {
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false),
                    GradesId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollmentGrades", x => new { x.CourseScheduleId, x.GradesId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollmentGrades_CourseEnrollments_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CourseEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollmentGrades_Grades_GradesId",
                        column: x => x.GradesId,
                        principalTable: "Grades",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CourseEnrollmentStudentInfo",
                columns: table => new
                {
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false),
                    EnrolledStudentsId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CourseEnrollmentStudentInfo", x => new { x.CourseScheduleId, x.EnrolledStudentsId });
                    table.ForeignKey(
                        name: "FK_CourseEnrollmentStudentInfo_CourseEnrollments_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CourseEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CourseEnrollmentStudentInfo_StudentInfo_EnrolledStudentsId",
                        column: x => x.EnrolledStudentsId,
                        principalTable: "StudentInfo",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "StudentGradingStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StudentStatus = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    CourseScheduleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StudentGradingStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_StudentGradingStatuses_CourseEnrollments_CourseScheduleId",
                        column: x => x.CourseScheduleId,
                        principalTable: "CourseEnrollments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_UserId",
                table: "Addresses",
                column: "UserId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_AreasOfStudy_CollegeId",
                table: "AreasOfStudy",
                column: "CollegeId");

            migrationBuilder.CreateIndex(
                name: "IX_Classrooms_BuildingId",
                table: "Classrooms",
                column: "BuildingId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAreaOfStudy_AreaOfStudyId",
                table: "CourseAreaOfStudy",
                column: "AreaOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseAreaOfStudy_CourseCatalogueId",
                table: "CourseAreaOfStudy",
                column: "CourseCatalogueId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDailySchedules_CourseId",
                table: "courseDailySchedules",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_courseDailySchedules_DoctorId",
                table: "courseDailySchedules",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollmentGrades_GradesId",
                table: "CourseEnrollmentGrades",
                column: "GradesId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollments_CourseScheduleId",
                table: "CourseEnrollments",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_CourseEnrollmentStudentInfo_EnrolledStudentsId",
                table: "CourseEnrollmentStudentInfo",
                column: "EnrolledStudentsId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesCatalogues_CourseCode",
                table: "CoursesCatalogues",
                column: "CourseCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSchedules_AreaOfStudyId",
                table: "CoursesSchedules",
                column: "AreaOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSchedules_ClassRoomId",
                table: "CoursesSchedules",
                column: "ClassRoomId");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSchedules_CourseNumber",
                table: "CoursesSchedules",
                column: "CourseNumber");

            migrationBuilder.CreateIndex(
                name: "IX_CoursesSchedules_SemesterId",
                table: "CoursesSchedules",
                column: "SemesterId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_JopInformationId",
                table: "EmployeeInfo",
                column: "JopInformationId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeInfo_UserId",
                table: "EmployeeInfo",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisites_ChildCourseId",
                table: "Prerequisites",
                column: "ChildCourseId");

            migrationBuilder.CreateIndex(
                name: "IX_Prerequisites_ParentCourseId_ChildCourseId",
                table: "Prerequisites",
                columns: new[] { "ParentCourseId", "ChildCourseId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SemestersInfo_AreaOfStudyId",
                table: "SemestersInfo",
                column: "AreaOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentGradingStatuses_CourseScheduleId",
                table: "StudentGradingStatuses",
                column: "CourseScheduleId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_AreaOfStudyId",
                table: "StudentInfo",
                column: "AreaOfStudyId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentInfo_StudentId",
                table: "StudentInfo",
                column: "StudentId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_RoleId",
                table: "Users",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UsersProfilePicture_UserId",
                table: "UsersProfilePicture",
                column: "UserId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "CourseAreaOfStudy");

            migrationBuilder.DropTable(
                name: "courseDailySchedules");

            migrationBuilder.DropTable(
                name: "CourseEnrollmentGrades");

            migrationBuilder.DropTable(
                name: "CourseEnrollmentStudentInfo");

            migrationBuilder.DropTable(
                name: "Prerequisites");

            migrationBuilder.DropTable(
                name: "StudentGradingStatuses");

            migrationBuilder.DropTable(
                name: "UsersProfilePicture");

            migrationBuilder.DropTable(
                name: "EmployeeInfo");

            migrationBuilder.DropTable(
                name: "Grades");

            migrationBuilder.DropTable(
                name: "StudentInfo");

            migrationBuilder.DropTable(
                name: "CourseEnrollments");

            migrationBuilder.DropTable(
                name: "JopInformation");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "CoursesSchedules");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Classrooms");

            migrationBuilder.DropTable(
                name: "CoursesCatalogues");

            migrationBuilder.DropTable(
                name: "SemestersInfo");

            migrationBuilder.DropTable(
                name: "Buildings");

            migrationBuilder.DropTable(
                name: "AreasOfStudy");

            migrationBuilder.DropTable(
                name: "colleges");
        }
    }
}
