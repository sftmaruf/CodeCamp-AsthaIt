using SMS.Domain.Entities;

namespace SMS.Domain.DTOs;

public class CourseDto
{
    public Guid Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    public string InstructorName { get; set; } = string.Empty;
}