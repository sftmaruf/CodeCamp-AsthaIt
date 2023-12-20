namespace SMS.Domain.Entities;

public class StudentRegistrationSemester
{
    public Guid Id { get; set; }
    public Guid SemesterId { get; set; } = Guid.Empty;
    public Semester? Semester { get; set; }
    public Guid StudentRegistrationId { get; set; } = Guid.Empty;
    public StudentRegistration? StudentRegistration { get; set; }
}