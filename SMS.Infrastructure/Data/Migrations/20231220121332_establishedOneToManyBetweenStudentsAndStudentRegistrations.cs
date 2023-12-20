using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedOneToManyBetweenStudentsAndStudentRegistrations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "StudentId",
                table: "StudentRegistrations",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations",
                column: "StudentId");

            migrationBuilder.AddForeignKey(
                name: "FK_StudentRegistrations_Students_StudentId",
                table: "StudentRegistrations",
                column: "StudentId",
                principalTable: "Students",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_StudentRegistrations_Students_StudentId",
                table: "StudentRegistrations");

            migrationBuilder.DropIndex(
                name: "IX_StudentRegistrations_StudentId",
                table: "StudentRegistrations");

            migrationBuilder.DropColumn(
                name: "StudentId",
                table: "StudentRegistrations");
        }
    }
}
