namespace SMS.Domain.DTOs;

public class BatchDto
{
    public Guid Id { get; set; }
    public string Name  { get; set; } = string.Empty;
    public int Year  { get; set; }
    public string DepartmentName { get; set; } = string.Empty;

}