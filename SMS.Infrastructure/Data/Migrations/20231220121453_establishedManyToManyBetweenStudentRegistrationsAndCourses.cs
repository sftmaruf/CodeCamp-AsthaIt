using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedManyToManyBetweenStudentRegistrationsAndCourses : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "CourseId",
                table: "StudentRegistrationCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.AddColumn<Guid>(
                name: "StudentRegistrationId",
                table: "StudentRegistrationCourses",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationCourses_CourseId",
                table: "StudentRegistrationCourses",
                column: "CourseId");

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrationCourses_StudentRegistrationId",
                table: "StudentRegistrationCourses",
                column: "StudentRegistrationId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrationCourses_Courses_CourseId",
                table: "StudentRegistrationCourses",
                column: "CourseId",
                principalTable: "Courses",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrationCourses_StudentRegistrations_StudentRegistrationId",
                table: "StudentRegistrationCourses",
                column: "StudentRegistrationId",
                principalTable: "StudentRegistrations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrationCourses_Courses_CourseId",
                table: "StudentRegistrationCourses");

            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrationCourses_StudentRegistrations_StudentRegistrationId",
                table: "StudentRegistrationCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrationCourses_CourseId",
                table: "StudentRegistrationCourses");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrationCourses_StudentRegistrationId",
                table: "StudentRegistrationCourses");

            migrationBuilder.DropColumn(
                name: "CourseId",
                table: "StudentRegistrationCourses");

            migrationBuilder.DropColumn(
                name: "StudentRegistrationId",
                table: "StudentRegistrationCourses");
        }
    }
}
