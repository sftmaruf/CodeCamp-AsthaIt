namespace SMS.Domain.Entities;

public class Batch
{
    public Guid Id { get; set; }
    public string Name  { get; set; } = string.Empty;
    public int Year  { get; set; }

    public static Batch Create(string name, int year)
    {
        var batch = new Batch {
            Name = name,
            Year = year
        };

        return batch;
    }
}