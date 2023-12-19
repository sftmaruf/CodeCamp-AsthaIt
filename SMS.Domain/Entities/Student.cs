namespace SMS.Domain.Entities;

public class Student {
    public Guid Id { get; set; }
    public string ClassId { get; set; } = string.Empty;
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public Guid BatchId { get; set; } = Guid.Empty;
    public Batch? Batch { get; set; }

    public static Student Create(string classId, string firstName, string middleName,
        string lastName, string joiningBatch, string degree, Guid departmentId, Guid batchId)
    {
        var student =  new Student
        {
            ClassId = classId,
            FirstName = firstName,
            MiddleName = middleName,
            LastName = lastName,
            JoiningBatch = joiningBatch,
            Degree = degree,
            BatchId = batchId
        };

        return student;
    }
}