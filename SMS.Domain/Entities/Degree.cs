namespace SMS.Domain.Entities;

public class Degree
{
    public Guid Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; } = Guid.Empty;
    public Department? Department { get; set; }

    public static Degree Create(string title, Guid departmentId)
    {
        var degree = new Degree
        {
            Title = title,
            DepartmentId = departmentId
        };

        return degree;
    }
}