namespace SMS.Domain.Entities;

public class StudentRegistrationCourse
{
    public Guid Id { get; set; }
    public Guid CourseId { get; set; } = Guid.Empty;
    public Course? Course { get; set; }
    public Guid StudentRegistrationId { get; set; } = Guid.Empty;
    public StudentRegistration? StudentRegistration { get; set; }
}