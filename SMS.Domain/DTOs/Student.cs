namespace SMS.Domain.DTOs;

public class Student
{
    public Guid Id { get; set; }
    public string ClassId { get; set; }
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
}