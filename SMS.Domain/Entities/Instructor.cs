namespace SMS.Domain.Entities;

public class Instructor
{
     public Guid Id { get; set; }
     public string? Name { get; set; }
     public List<Course> Courses { get; set; } = new();

     public static Instructor Create(string name)
     {
        var instructor = new Instructor
        {
            Name = name
        };

        return instructor;
     }
}