using Microsoft.EntityFrameworkCore;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Infrastructure.Data;

public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Student> Students { get; set; }
    public DbSet<Batch> Batches { get; set; }
    public DbSet<Department> Departments { get; set; }
    public DbSet<Degree> Degrees { get; set; }
    public DbSet<Instructor> Instructors { get; set; }
}