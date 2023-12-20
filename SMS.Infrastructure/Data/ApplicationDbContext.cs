using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

       protected override void OnModelCreating(ModelBuilder modelBuilder)
       {
            modelBuilder.Entity<Department>().HasData(
                new Department { Id = new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd"), Name = "Department of Software Engineering" },
                new Department { Id = new Guid("79aedfda-4b1e-45ab-bdc7-feafdddcfd6a"), Name = "Department of English" },
                new Department { Id = new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed"), Name = "Department of Law" }
            );

            modelBuilder.Entity<Degree>().HasData(
                new Degree { Id = new Guid("71e87e5c-2ab2-4acb-a079-850792ec0485"), Title = "BSc", DepartmentId = new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd") },
                new Degree { Id = new Guid("b49ef72c-66ed-457f-bdd7-59add3c0ffbb"), Title = "LLB", DepartmentId = new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed") },
                new Degree { Id = new Guid("3b46307a-7565-47e0-b0aa-d0a290ca7b0a"), Title = "BA", DepartmentId = new Guid("79aedfda-4b1e-45ab-bdc7-feafdddcfd6a") }
            );

            modelBuilder.Entity<Batch>().HasData(
                new Batch { Id = new Guid("a202a227-811b-4404-b30e-707a495fcada"), Name = "26", Year = 2018, DepartmentId = new Guid("40e2e095-c0bc-4127-a7c5-26613771b6dd") },
                new Batch { Id = new Guid("d335042c-9d3f-46be-b310-78cb0cbfe4f3"), Name = "1", Year = 2019, DepartmentId = new Guid("447d4bdd-02d0-45a8-8233-9194a2f375ed") }
            );

            modelBuilder.Entity<Instructor>().HasData(
                new Instructor { Id = new Guid("55335290-bb42-4b55-8613-a6067d359eed"), Name = "Osama" },
                new Instructor { Id = new Guid("bbd8efde-c3c2-4974-a9f0-259e3ead2d75"), Name = "Jabed" },
                new Instructor { Id = new Guid("9e7a731d-b036-4fd7-98fb-304604ee3193"), Name = "Shammem" }
            );

            modelBuilder.Entity<Semester>().HasData(
                new Semester { Id = new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), Month = 1, Year = 2018, Duration = 6 },
                new Semester { Id = new Guid("9557946c-0595-491c-bd5f-cbee89d19236"), Month = 7, Year = 2019, Duration = 6 }
            );

            modelBuilder.Entity<Course>().HasData(
                new Course { Id = new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"), Name = "Introduction to Software Engineering", CourseCode = "SE101", Credit = 3, InstructorId = new Guid("bbd8efde-c3c2-4974-a9f0-259e3ead2d75") },
                new Course { Id = new Guid("5187c93a-88bb-457e-9187-e6ac0ef200d5"), Name = "Introduction to Web Programming", CourseCode = "SE301", Credit = 3, InstructorId = new Guid("55335290-bb42-4b55-8613-a6067d359eed") },
                new Course { Id = new Guid("da2c6d1f-a060-40c8-8881-f233c247341a"), Name = "Introduction to English", CourseCode = "ENG103", Credit = 3, InstructorId = new Guid("9e7a731d-b036-4fd7-98fb-304604ee3193") }
            );

            modelBuilder.Entity<SemesterCourse>().HasData(
                new SemesterCourse { Id = new Guid("0a6f93d2-c967-43f5-a7c2-72146e297b56"), SemesterId = new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), CourseId = new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941") },
                new SemesterCourse { Id = new Guid("93243348-d24f-47b2-a70d-f929ae76fccc"), SemesterId = new Guid("9557946c-0595-491c-bd5f-cbee89d19236"), CourseId = new Guid("5187c93a-88bb-457e-9187-e6ac0ef200d5") },
                new SemesterCourse { Id = new Guid("6257c6eb-2d03-47fe-a887-3de118b68913"), SemesterId = new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), CourseId = new Guid("da2c6d1f-a060-40c8-8881-f233c247341a") }
            );

            modelBuilder.Entity<Student>().HasData(
                new Student { Id = new Guid("edfc80e0-1c2d-4112-8b47-56371dade5ab"), ClassId = "182-35-2530", BatchId = new Guid("a202a227-811b-4404-b30e-707a495fcada"), FirstName = "Md", MiddleName = "Shafayet", LastName = "Maruf" },
                new Student { Id = new Guid("a6660f6e-96bb-4d2d-9a45-f28edc0b254d"), ClassId = "142-12-1031", BatchId = new Guid("d335042c-9d3f-46be-b310-78cb0cbfe4f3"), FirstName = "Md", MiddleName = "Mosabbir", LastName = "" }
            );

            modelBuilder.Entity<StudentRegistration>().HasData(
                new StudentRegistration { Id = new Guid("4b3efc3c-276a-4a30-9764-8a4782ce7136"), SemesterId = new Guid("72c3124d-1810-4604-8188-8d2952e6d804"), StudentId = new Guid("edfc80e0-1c2d-4112-8b47-56371dade5ab") },
                new StudentRegistration { Id = new Guid("2b03ae45-f974-43ca-bd42-4c91849b7599"), SemesterId = new Guid("9557946c-0595-491c-bd5f-cbee89d19236"), StudentId = new Guid("a6660f6e-96bb-4d2d-9a45-f28edc0b254d") }
            );

            modelBuilder.Entity<StudentRegistrationCourse>().HasData(
                new StudentRegistrationCourse { Id = new Guid("09055894-c849-43b8-aab1-46f9f49935bb"), CourseId = new Guid("b13d51b9-dacb-497a-8a96-cfc6fa316941"), StudentRegistrationId = new Guid("4b3efc3c-276a-4a30-9764-8a4782ce7136") }
            );

    }

    public DbSet<Student> Students { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
    public DbSet<Semester> Semesters { get; set; }
    public DbSet<Course> Courses { get; set; }
    public DbSet<StudentRegistration> StudentRegistrations { get; set; }
    public DbSet<StudentRegistrationCourse> StudentRegistrationCourses { get; set; }
    public DbSet<SemesterCourse> SemesterCourses { get; set; }
}