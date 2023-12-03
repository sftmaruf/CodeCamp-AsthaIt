namespace Entities;

public class Semester 
{
    public string SemesterCode { get; set; } = string.Empty;
    public string Year { get; set; } = string.Empty;
    public int NumberOfCredits { get; set; } = 0;
    public List<SemesterCourse> Courses { get; set; } = new();

    public string GetSemesterCode()
    {
        return SemesterCode + Year;
    }
}