using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedOneToManyBetweenStudentRegistrationsAndSemesters : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "SemesterId",
                table: "StudentRegistrations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_SemesterId",
                table: "StudentRegistrations",
                column: "SemesterId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Semesters_SemesterId",
                table: "StudentRegistrations",
                column: "SemesterId",
                principalTable: "Semesters",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Semesters_SemesterId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_SemesterId",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "SemesterId",
                table: "StudentRegistrations");
        }
    }
}
