namespace SMS.Domain.Entities;

public class Batch
{
    public Guid Id { get; set; }
    public string Name  { get; set; } = string.Empty;
    public int Year  { get; set; }
    public Guid DepartmentId  { get; set; } = Guid.Empty;
    public Department? Department  { get; set; }
    public List<Student> Students { get; set; } = new();

    public static Batch Create(string name, int year, Guid departmentId)
    {
        var batch = new Batch {
            Name = name,
            Year = year,
            DepartmentId = departmentId
        };

        return batch;
    }
}