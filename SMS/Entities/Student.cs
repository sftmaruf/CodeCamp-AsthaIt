namespace Entities;

public class Student : IEntity
{
    public Guid Id { get; set; }
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;
    public List<Semester> AttendedSemesters { get; set; } = new();

    public void FillId()
    {
        if(Id == Guid.Empty) Id = Guid.NewGuid();
    }
}