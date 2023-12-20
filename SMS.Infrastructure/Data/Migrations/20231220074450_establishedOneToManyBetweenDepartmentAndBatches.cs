using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class establishedOneToManyBetweenDepartmentAndBatches : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "DepartmentId",
                table: "Batches",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Batches_DepartmentId",
                table: "Batches",
                column: "DepartmentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Batches_Departments_DepartmentId",
                table: "Batches",
                column: "DepartmentId",
                principalTable: "Departments",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Batches_Departments_DepartmentId",
                table: "Batches");

            migrationBuilder.DropIndex(
                name: "IX_Batches_DepartmentId",
                table: "Batches");

            migrationBuilder.DropColumn(
                name: "DepartmentId",
                table: "Batches");
        }
    }
}
