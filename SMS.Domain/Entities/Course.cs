namespace SMS.Domain.Entities;

public class Course {
    public string Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    // public  List<DepartmenEO>? Departments { get; set; }

    public static Course Create(string courseCode, string Name, int Credit)
    {
        var course =  new Course
        {
            CourseCode = courseCode,
            Name = Name,
            Credit = Credit
        };

        return course;
    }
}