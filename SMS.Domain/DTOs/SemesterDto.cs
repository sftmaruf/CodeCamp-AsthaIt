namespace SMS.Domain.DTOs;

public class SemesterDto
{
    public Guid Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
}