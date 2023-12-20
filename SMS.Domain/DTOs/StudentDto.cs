namespace SMS.Domain.DTOs;

public class StudentDto
{
    public Guid Id { get; set; }
    public string ClassId { get; set; } = string.Empty;
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public string Batch { get; set; } = string.Empty;
}