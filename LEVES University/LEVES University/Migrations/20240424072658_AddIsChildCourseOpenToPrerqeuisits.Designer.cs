﻿// <auto-generated />
using System;
using LEVES_University.DBContext;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace LEVES_University.Migrations
{
    [DbContext(typeof(LevesEntities))]
    [Migration("20240424072658_AddIsChildCourseOpenToPrerqeuisits")]
    partial class AddIsChildCourseOpenToPrerqeuisits
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.4")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("CourseEnrollmentGrades", b =>
                {
                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("GradesId")
                        .HasColumnType("int");

                    b.HasKey("CourseScheduleId", "GradesId");

                    b.HasIndex("GradesId");

                    b.ToTable("CourseEnrollmentGrades");
                });

            modelBuilder.Entity("CourseEnrollmentStudentInfo", b =>
                {
                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.Property<int>("EnrolledStudentsId")
                        .HasColumnType("int");

                    b.HasKey("CourseScheduleId", "EnrolledStudentsId");

                    b.HasIndex("EnrolledStudentsId");

                    b.ToTable("CourseEnrollmentStudentInfo");
                });

            modelBuilder.Entity("LEVES_University.Models.Address", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("City")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street1")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("Street2")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Zip")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("Addresses");
                });

            modelBuilder.Entity("LEVES_University.Models.AreaOfStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CollegeId")
                        .HasColumnType("int");

                    b.Property<string>("StudyTitle")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.HasIndex("CollegeId");

                    b.HasIndex("StudyTitle")
                        .IsUnique();

                    b.ToTable("AreasOfStudy");
                });

            modelBuilder.Entity("LEVES_University.Models.Building", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Buildings");
                });

            modelBuilder.Entity("LEVES_University.Models.ClassRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("BuildingId")
                        .HasColumnType("int");

                    b.Property<int>("MaxSeating")
                        .HasColumnType("int");

                    b.Property<string>("RoomCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.HasKey("Id");

                    b.HasIndex("BuildingId");

                    b.ToTable("Classrooms");
                });

            modelBuilder.Entity("LEVES_University.Models.College", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.HasKey("Id");

                    b.ToTable("Colleges");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseAreaOfStudy", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaOfStudyId")
                        .HasColumnType("int");

                    b.Property<int>("CourseCatalogueId")
                        .HasColumnType("int");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaOfStudyId");

                    b.HasIndex("CourseCatalogueId");

                    b.ToTable("CourseAreaOfStudy");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseCatalogue", b =>
                {
                    b.Property<int>("CourseNumber")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("CourseNumber"));

                    b.Property<string>("CourseCode")
                        .IsRequired()
                        .HasMaxLength(10)
                        .HasColumnType("nvarchar(10)");

                    b.Property<string>("CourseDescription")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<string>("CourseTitle")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<int>("CreditHours")
                        .HasColumnType("int");

                    b.HasKey("CourseNumber");

                    b.HasIndex("CourseCode")
                        .IsUnique();

                    b.ToTable("CoursesCatalogues");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseDailySchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseId")
                        .HasColumnType("int");

                    b.Property<DateTime>("Date")
                        .HasColumnType("datetime2");

                    b.Property<int>("DoctorId")
                        .HasColumnType("int");

                    b.Property<TimeSpan>("EndTime")
                        .HasColumnType("time");

                    b.Property<TimeSpan>("StartTime")
                        .HasColumnType("time");

                    b.HasKey("Id");

                    b.HasIndex("CourseId");

                    b.HasIndex("DoctorId");

                    b.ToTable("courseDailySchedules");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseEnrollment", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("CourseScheduleId");

                    b.ToTable("CourseEnrollments");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseSchedule", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int?>("AreaOfStudyId")
                        .HasColumnType("int");

                    b.Property<int>("ClassRoomId")
                        .HasColumnType("int");

                    b.Property<int>("CourseNumber")
                        .HasColumnType("int");

                    b.Property<int>("NumberOfSeats")
                        .HasColumnType("int");

                    b.Property<int>("SemesterId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaOfStudyId");

                    b.HasIndex("ClassRoomId");

                    b.HasIndex("CourseNumber");

                    b.HasIndex("SemesterId");

                    b.ToTable("CoursesSchedules");
                });

            modelBuilder.Entity("LEVES_University.Models.EmployeeInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("JopInformationId")
                        .HasColumnType("int");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<double>("YearlyPay")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.HasIndex("JopInformationId");

                    b.HasIndex("UserId");

                    b.ToTable("EmployeeInfo");
                });

            modelBuilder.Entity("LEVES_University.Models.Grades", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Grade")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Grades");
                });

            modelBuilder.Entity("LEVES_University.Models.JopInformation", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.Property<double>("MaxPay")
                        .HasColumnType("float");

                    b.Property<double>("MinPay")
                        .HasColumnType("float");

                    b.Property<string>("Requirements")
                        .IsRequired()
                        .HasMaxLength(250)
                        .HasColumnType("nvarchar(250)");

                    b.HasKey("Id");

                    b.ToTable("JopInformation");
                });

            modelBuilder.Entity("LEVES_University.Models.Prerequisites", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("ChildCourseId")
                        .HasColumnType("int");

                    b.Property<bool>("IsChildCourseOpen")
                        .HasColumnType("bit");

                    b.Property<int>("ParentCourseId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("ChildCourseId");

                    b.HasIndex("ParentCourseId", "ChildCourseId")
                        .IsUnique();

                    b.ToTable("Prerequisites");
                });

            modelBuilder.Entity("LEVES_University.Models.Role", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("LEVES_University.Models.SemesterInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaOfStudyId")
                        .HasColumnType("int");

                    b.Property<DateTime>("EndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EnrollmentEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("EnrollmentStartDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("StartDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Year")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("AreaOfStudyId");

                    b.ToTable("SemestersInfo");
                });

            modelBuilder.Entity("LEVES_University.Models.StudentGradingStatus", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CourseScheduleId")
                        .HasColumnType("int");

                    b.Property<string>("StudentStatus")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.HasIndex("CourseScheduleId");

                    b.ToTable("StudentGradingStatuses");
                });

            modelBuilder.Entity("LEVES_University.Models.StudentInfo", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("AreaOfStudyId")
                        .HasColumnType("int");

                    b.Property<double>("GPA")
                        .HasColumnType("float");

                    b.Property<int>("Grade")
                        .HasColumnType("int");

                    b.Property<string>("StudentId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("AreaOfStudyId");

                    b.HasIndex("StudentId")
                        .IsUnique();

                    b.ToTable("StudentInfo");
                });

            modelBuilder.Entity("LEVES_University.Models.UserProfilePicture", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("ImageName")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ImagePath")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UsersProfilePicture");
                });

            modelBuilder.Entity("LEVES_University.Models.Users", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("FirstName")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<bool>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("LastName")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)");

                    b.Property<long>("NTID")
                        .HasColumnType("bigint");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .IsRequired()
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("RoleId")
                        .HasColumnType("int");

                    b.HasKey("Id");

                    b.HasIndex("Email")
                        .IsUnique();

                    b.HasIndex("NTID")
                        .IsUnique();

                    b.HasIndex("PhoneNumber")
                        .IsUnique();

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("CourseEnrollmentGrades", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseEnrollment", null)
                        .WithMany()
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.Grades", null)
                        .WithMany()
                        .HasForeignKey("GradesId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("CourseEnrollmentStudentInfo", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseEnrollment", null)
                        .WithMany()
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.StudentInfo", null)
                        .WithMany()
                        .HasForeignKey("EnrolledStudentsId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("LEVES_University.Models.Address", b =>
                {
                    b.HasOne("LEVES_University.Models.Users", "User")
                        .WithOne("Address")
                        .HasForeignKey("LEVES_University.Models.Address", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LEVES_University.Models.AreaOfStudy", b =>
                {
                    b.HasOne("LEVES_University.Models.College", "College")
                        .WithMany("AreasOfStudy")
                        .HasForeignKey("CollegeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("College");
                });

            modelBuilder.Entity("LEVES_University.Models.ClassRoom", b =>
                {
                    b.HasOne("LEVES_University.Models.Building", "Building")
                        .WithMany()
                        .HasForeignKey("BuildingId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Building");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseAreaOfStudy", b =>
                {
                    b.HasOne("LEVES_University.Models.AreaOfStudy", "AreaOfStudy")
                        .WithMany("CourseAreasOfStudy")
                        .HasForeignKey("AreaOfStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.CourseCatalogue", "CourseCatalogue")
                        .WithMany()
                        .HasForeignKey("CourseCatalogueId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaOfStudy");

                    b.Navigation("CourseCatalogue");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseDailySchedule", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseSchedule", "CourseSchedule")
                        .WithMany("DailySchedules")
                        .HasForeignKey("CourseId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.EmployeeInfo", "Doctor")
                        .WithMany()
                        .HasForeignKey("DoctorId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseSchedule");

                    b.Navigation("Doctor");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseEnrollment", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseSchedule", "CourseSchedule")
                        .WithMany()
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("CourseSchedule");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseSchedule", b =>
                {
                    b.HasOne("LEVES_University.Models.SemesterInfo", null)
                        .WithMany("CourseSchedules")
                        .HasForeignKey("AreaOfStudyId");

                    b.HasOne("LEVES_University.Models.ClassRoom", "ClassRoom")
                        .WithMany()
                        .HasForeignKey("ClassRoomId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.CourseCatalogue", "CourseCatalogue")
                        .WithMany("CourseSchedules")
                        .HasForeignKey("CourseNumber")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.SemesterInfo", "Semester")
                        .WithMany()
                        .HasForeignKey("SemesterId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("ClassRoom");

                    b.Navigation("CourseCatalogue");

                    b.Navigation("Semester");
                });

            modelBuilder.Entity("LEVES_University.Models.EmployeeInfo", b =>
                {
                    b.HasOne("LEVES_University.Models.JopInformation", "JopInformation")
                        .WithMany("Employees")
                        .HasForeignKey("JopInformationId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("JopInformation");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LEVES_University.Models.Prerequisites", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseCatalogue", "ChildCourse")
                        .WithMany()
                        .HasForeignKey("ChildCourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.CourseCatalogue", "ParentCourse")
                        .WithMany()
                        .HasForeignKey("ParentCourseId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("ChildCourse");

                    b.Navigation("ParentCourse");
                });

            modelBuilder.Entity("LEVES_University.Models.SemesterInfo", b =>
                {
                    b.HasOne("LEVES_University.Models.AreaOfStudy", "AreaOfStudy")
                        .WithMany()
                        .HasForeignKey("AreaOfStudyId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("AreaOfStudy");
                });

            modelBuilder.Entity("LEVES_University.Models.StudentGradingStatus", b =>
                {
                    b.HasOne("LEVES_University.Models.CourseEnrollment", "CourseEnrollment")
                        .WithMany("GradingStatuses")
                        .HasForeignKey("CourseScheduleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("CourseEnrollment");
                });

            modelBuilder.Entity("LEVES_University.Models.StudentInfo", b =>
                {
                    b.HasOne("LEVES_University.Models.AreaOfStudy", "AreaOfStudy")
                        .WithMany("Students")
                        .HasForeignKey("AreaOfStudyId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("LEVES_University.Models.Users", "User")
                        .WithMany()
                        .HasForeignKey("StudentId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("AreaOfStudy");

                    b.Navigation("User");
                });

            modelBuilder.Entity("LEVES_University.Models.UserProfilePicture", b =>
                {
                    b.HasOne("LEVES_University.Models.Users", "User")
                        .WithOne("UserProfilePicture")
                        .HasForeignKey("LEVES_University.Models.UserProfilePicture", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("LEVES_University.Models.Users", b =>
                {
                    b.HasOne("LEVES_University.Models.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("LEVES_University.Models.AreaOfStudy", b =>
                {
                    b.Navigation("CourseAreasOfStudy");

                    b.Navigation("Students");
                });

            modelBuilder.Entity("LEVES_University.Models.College", b =>
                {
                    b.Navigation("AreasOfStudy");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseCatalogue", b =>
                {
                    b.Navigation("CourseSchedules");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseEnrollment", b =>
                {
                    b.Navigation("GradingStatuses");
                });

            modelBuilder.Entity("LEVES_University.Models.CourseSchedule", b =>
                {
                    b.Navigation("DailySchedules");
                });

            modelBuilder.Entity("LEVES_University.Models.JopInformation", b =>
                {
                    b.Navigation("Employees");
                });

            modelBuilder.Entity("LEVES_University.Models.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("LEVES_University.Models.SemesterInfo", b =>
                {
                    b.Navigation("CourseSchedules");
                });

            modelBuilder.Entity("LEVES_University.Models.Users", b =>
                {
                    b.Navigation("Address")
                        .IsRequired();

                    b.Navigation("UserProfilePicture")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
