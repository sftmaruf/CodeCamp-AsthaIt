namespace SMS.Domain.Entities;

public class Course {
    public Guid Id { get; set; }
    public string CourseCode { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public int Credit { get; set; }
    public Guid SemesterId { get; set; } = Guid.Empty;
    public Semester? Semester { get; set; }
    public Guid BatchId { get; set; } = Guid.Empty;
    public Batch? Batch { get; set; }
    public Guid InstructorId { get; set; } = Guid.Empty;
    public Instructor? Instructor { get; set; }

    public static Course Create(string courseCode, string Name, int Credit, Guid semesterId, Guid batchId, Guid instructorId)
    {
        var course =  new Course
        {
            CourseCode = courseCode,
            Name = Name,
            Credit = Credit,
            SemesterId = semesterId,
            BatchId = batchId,
            InstructorId = instructorId
        };

        return course;
    }
}