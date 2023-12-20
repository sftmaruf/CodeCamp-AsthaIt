using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedOneToManyBetweenInstructorsAndCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourse_Courses_CourseId",
                table: "SemesterCourse");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourse_Semesters_SemesterId",
                table: "SemesterCourse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterCourse",
                table: "SemesterCourse");

            migrationBuilder.RenameTable(
                name: "SemesterCourse",
                newName: "SemesterCourses");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterCourse_SemesterId",
                table: "SemesterCourses",
                newName: "IX_SemesterCourses_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterCourse_CourseId",
                table: "SemesterCourses",
                newName: "IX_SemesterCourses_CourseId");

            migrationBuilder.AddColumn<Guid>(
                name: "InstructorId",
                table: "Courses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterCourses",
                table: "SemesterCourses",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses",
                column: "InstructorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses",
                column: "InstructorId",
                principalTable: "Instructors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourses_Courses_CourseId",
                table: "SemesterCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourses_Semesters_SemesterId",
                table: "SemesterCourses",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Courses_Instructors_InstructorId",
                table: "Courses");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourses_Courses_CourseId",
                table: "SemesterCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_SemesterCourses_Semesters_SemesterId",
                table: "SemesterCourses");

            migrationBuilder.DropIndex(
                name: "IX_Courses_InstructorId",
                table: "Courses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_SemesterCourses",
                table: "SemesterCourses");

            migrationBuilder.DropColumn(
                name: "InstructorId",
                table: "Courses");

            migrationBuilder.RenameTable(
                name: "SemesterCourses",
                newName: "SemesterCourse");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterCourses_SemesterId",
                table: "SemesterCourse",
                newName: "IX_SemesterCourse_SemesterId");

            migrationBuilder.RenameIndex(
                name: "IX_SemesterCourses_CourseId",
                table: "SemesterCourse",
                newName: "IX_SemesterCourse_CourseId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_SemesterCourse",
                table: "SemesterCourse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourse_Courses_CourseId",
                table: "SemesterCourse",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SemesterCourse_Semesters_SemesterId",
                table: "SemesterCourse",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
