using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SMS.Infrastructure.Data.Migrations
{
    /// <inheritdoc />
    public partial class seededValue : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd"), "Department of Software Engineering" },
                    { new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed"), "Department of Law" },
                    { new Guid("79aedfda-4b1e-45ab-bdc7-feafdddcfd6a"), "Department of English" }
                });

            migrationBuilder.InsertData(
                table: "Instructors",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { new Guid("55335290-bb42-4b55-8613-a6067d359eed"), "Osama" },
                    { new Guid("9e7a731d-b036-4fd7-98fb-304604ee3193"), "Shammem" },
                    { new Guid("bbd8efde-c3c2-4974-a9f0-259e3ead2d75"), "Jabed" }
                });

            migrationBuilder.InsertData(
                table: "Semesters",
                columns: new[] { "Id", "Duration", "Month", "Year" },
                values: new object[,]
                {
                    { new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), 6, 1, 2018 },
                    { new Guid("9557946c-0595-491c-bd5f-cbee89d19236"), 6, 7, 2019 }
                });

            migrationBuilder.InsertData(
                table: "Batches",
                columns: new[] { "Id", "DepartmentId", "Name", "Year" },
                values: new object[,]
                {
                    { new Guid("a202a227-811b-4404-b30e-707a495fcada"), new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd"), "26", 2018 },
                    { new Guid("d335042c-9d3f-46be-b310-78cb0cbfe4f3"), new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed"), "1", 2019 }
                });

            migrationBuilder.InsertData(
                table: "Courses",
                columns: new[] { "Id", "CourseCode", "Credit", "InstructorId", "Name" },
                values: new object[,]
                {
                    { new Guid("5187c93a-88bb-457e-9187-e6ac0ef200d5"), "SE301", 3, new Guid("55335290-bb42-4b55-8613-a6067d359eed"), "Introduction to Web Programming" },
                    { new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"), "SE101", 3, new Guid("bbd8efde-c3c2-4974-a9f0-259e3ead2d75"), "Introduction to Software Engineering" },
                    { new Guid("da2c6d1f-a060-40c8-8881-f233c247341a"), "ENG103", 3, new Guid("9e7a731d-b036-4fd7-98fb-304604ee3193"), "Introduction to English" }
                });

            migrationBuilder.InsertData(
                table: "Degrees",
                columns: new[] { "Id", "DepartmentId", "Title" },
                values: new object[,]
                {
                    { new Guid("3b46307a-7565-47e0-b0aa-d0a290ca7b0a"), new Guid("79aedfda-4b1e-45ab-bdc7-feafdddcfd6a"), "BA" },
                    { new Guid("71e87e5c-2ab2-4acb-a079-850792ec0485"), new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd"), "BSc" },
                    { new Guid("b49ef72c-66ed-457f-bdd7-59add3c0ffbb"), new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed"), "LLB" }
                });

            migrationBuilder.InsertData(
                table: "SemesterCourses",
                columns: new[] { "Id", "CourseId", "SemesterId" },
                values: new object[,]
                {
                    { new Guid("0a6f93d2-c967-43f5-a7c2-72146e297b56"), new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"), new Guid("72c3124d-1810-4604-8188-8d2952e6d804") },
                    { new Guid("6257c6eb-2d03-47fe-a887-3de118b68913"), new Guid("da2c6d1f-a060-40c8-8881-f233c247341a"), new Guid("72c3124d-1810-4604-8188-8d2952e6d804") },
                    { new Guid("93243348-d24f-47b2-a70d-f929ae76fccc"), new Guid("5187c93a-88bb-457e-9187-e6ac0ef200d5"), new Guid("9557946c-0595-491c-bd5f-cbee89d19236") }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "BatchId", "ClassId", "FirstName", "JoiningBatch", "LastName", "MiddleName" },
                values: new object[,]
                {
                    { new Guid("a6660f6e-96bb-4d2d-9a45-f28edc0b254d"), new Guid("d335042c-9d3f-46be-b310-78cb0cbfe4f3"), "142-12-1031", "Md", "", "", "Mosabbir" },
                    { new Guid("edfc80e0-1c2d-4112-8b47-56371dade5ab"), new Guid("a202a227-811b-4404-b30e-707a495fcada"), "182-35-2530", "Md", "", "Maruf", "Shafayet" }
                });

            migrationBuilder.InsertData(
                table: "StudentRegistrations",
                columns: new[] { "Id", "SemesterId", "StudentId" },
                values: new object[,]
                {
                    { new Guid("2b03ae45-f974-43ca-bd42-4c91849b7599"), new Guid("9557946c-0595-491c-bd5f-cbee89d19236"), new Guid("a6660f6e-96bb-4d2d-9a45-f28edc0b254d") },
                    { new Guid("4b3efc3c-276a-4a30-9764-8a4782ce7136"), new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), new Guid("edfc80e0-1c2d-4112-8b47-56371dade5ab") }
                });

            migrationBuilder.InsertData(
                table: "StudentRegistrationCourses",
                columns: new[] { "Id", "CourseId", "StudentRegistrationId" },
                values: new object[] { new Guid("09055894-c849-43b8-aab1-46f9f49935bb"), new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"), new Guid("4b3efc3c-276a-4a30-9764-8a4782ce7136") });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: new Guid("3b46307a-7565-47e0-b0aa-d0a290ca7b0a"));

            migrationBuilder.DeleteData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: new Guid("71e87e5c-2ab2-4acb-a079-850792ec0485"));

            migrationBuilder.DeleteData(
                table: "Degrees",
                keyColumn: "Id",
                keyValue: new Guid("b49ef72c-66ed-457f-bdd7-59add3c0ffbb"));

            migrationBuilder.DeleteData(
                table: "SemesterCourses",
                keyColumn: "Id",
                keyValue: new Guid("0a6f93d2-c967-43f5-a7c2-72146e297b56"));

            migrationBuilder.DeleteData(
                table: "SemesterCourses",
                keyColumn: "Id",
                keyValue: new Guid("6257c6eb-2d03-47fe-a887-3de118b68913"));

            migrationBuilder.DeleteData(
                table: "SemesterCourses",
                keyColumn: "Id",
                keyValue: new Guid("93243348-d24f-47b2-a70d-f929ae76fccc"));

            migrationBuilder.DeleteData(
                table: "StudentRegistrationCourses",
                keyColumn: "Id",
                keyValue: new Guid("09055894-c849-43b8-aab1-46f9f49935bb"));

            migrationBuilder.DeleteData(
                table: "StudentRegistrations",
                keyColumn: "Id",
                keyValue: new Guid("2b03ae45-f974-43ca-bd42-4c91849b7599"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("5187c93a-88bb-457e-9187-e6ac0ef200d5"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"));

            migrationBuilder.DeleteData(
                table: "Courses",
                keyColumn: "Id",
                keyValue: new Guid("da2c6d1f-a060-40c8-8881-f233c247341a"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("79aedfda-4b1e-45ab-bdc7-feafdddcfd6a"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("9557946c-0595-491c-bd5f-cbee89d19236"));

            migrationBuilder.DeleteData(
                table: "StudentRegistrations",
                keyColumn: "Id",
                keyValue: new Guid("4b3efc3c-276a-4a30-9764-8a4782ce7136"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("a6660f6e-96bb-4d2d-9a45-f28edc0b254d"));

            migrationBuilder.DeleteData(
                table: "Batches",
                keyColumn: "Id",
                keyValue: new Guid("d335042c-9d3f-46be-b310-78cb0cbfe4f3"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("55335290-bb42-4b55-8613-a6067d359eed"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("9e7a731d-b036-4fd7-98fb-304604ee3193"));

            migrationBuilder.DeleteData(
                table: "Instructors",
                keyColumn: "Id",
                keyValue: new Guid("bbd8efde-c3c2-4974-a9f0-259e3ead2d75"));

            migrationBuilder.DeleteData(
                table: "Semesters",
                keyColumn: "Id",
                keyValue: new Guid("72c3124d-1810-4604-8188-8d2952e6d804"));

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "Id",
                keyValue: new Guid("edfc80e0-1c2d-4112-8b47-56371dade5ab"));

            migrationBuilder.DeleteData(
                table: "Batches",
                keyColumn: "Id",
                keyValue: new Guid("a202a227-811b-4404-b30e-707a495fcada"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed"));

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "Id",
                keyValue: new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd"));
        }
    }
}
