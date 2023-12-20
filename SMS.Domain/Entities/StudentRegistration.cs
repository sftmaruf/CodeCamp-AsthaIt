namespace SMS.Domain.Entities;

public class StudentRegistration
{
    public Guid Id { get; set; }
    public Guid StudentId { get; set; } = Guid.Empty;
    public Student? Student { get; set; }
    public Guid SemesterId { get; set; } = Guid.Empty;
    public Semester? Semester { get; set; }
    public List<StudentRegistrationCourse> StudentRegistrationCourses { get; set; } = new();
}