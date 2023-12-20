namespace SMS.Domain.Entities;

public class Semester
{
    public Guid Id { get; set; }
    public int Month { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }
    public List<StudentRegistration> StudentRegistrations { get; set; } = new();
    public List<SemesterCourse> SemesterCourses { get; set; } = new();

    public static Semester Create(int month, int year, int duration)
    {
        var semester = new Semester {
            Month = month,
            Year = year,
            Duration = duration
        };

        return semester;
    }
}