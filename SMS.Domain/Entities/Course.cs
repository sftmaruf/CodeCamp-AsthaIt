namespace SMS.Domain.Entities;

public class Course {
    public Guid Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    public Guid InstructorId { get; set; } = Guid.Empty;
    public Instructor? Instructor { get; set; }
    public List<StudentRegistrationCourse> StudentRegistrationCourses { get; set; } = new();
    public List<SemesterCourse> SemesterCourses { get; set; } = new();


    public static Course Create(string courseCode, string Name, int Credit, Guid instructorId)
    {
        var course =  new Course
        {
            CourseCode = courseCode,
            Name = Name,
            Credit = Credit,
            InstructorId = instructorId
        };

        return course;
    }
}