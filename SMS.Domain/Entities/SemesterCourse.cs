namespace SMS.Domain.Entities;

public class SemesterCourse
{
    public Guid Id { get; set; }
    public Guid SemesterId { get; set; } = Guid.Empty;
    public Semester? Semester { get; set; }
    public Guid CourseId { get; set; } = Guid.Empty;
    public Course? Course { get; set; }
}