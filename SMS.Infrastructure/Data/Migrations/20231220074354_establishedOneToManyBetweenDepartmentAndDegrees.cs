using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedOneToManyBetweenDepartmentAndDegrees : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Degrees",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Degrees_DepartmentId",
                table: "Degrees",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Degrees_Departments_DepartmentId",
                table: "Degrees",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Degrees_Departments_DepartmentId",
                table: "Degrees");

            migrationBuilder.DropIndex(
                name: "IX_Degrees_DepartmentId",
                table: "Degrees");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Degrees");
        }
    }
}
