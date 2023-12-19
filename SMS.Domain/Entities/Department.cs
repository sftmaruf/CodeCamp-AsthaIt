namespace SMS.Domain.Entities;

public class Department
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public List<Batch> Batches { get; set; } = new();
    public List<Degree> Degrees { get; set; } = new();

    public static Department Create(string name)
    {
        var department = new Department
        {
            Name = name
        };

        return department;
    }
}