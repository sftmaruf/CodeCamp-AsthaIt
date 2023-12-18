namespace SMS.Domain.Entities;

public class Student {
    public Guid Id { get; set; }
    public string ClassId { get; set; }
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    // public List<Semester> AttendedSemesters { get; set; } = new();

    public static Student Create(string classId, string firstName, string middleName,
        string lastName, string joiningBatch, string department, string degree)
    {
        var student =  new Student
        {
            ClassId = classId,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            JoiningBatch = joiningBatch,
            Department = department,
            Degree = degree
        };

        return student;
    }
}