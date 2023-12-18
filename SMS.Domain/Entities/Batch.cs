namespace SMS.Domain.Entities;

public class Batch
{
    public Guid Id;
    public string Name = string.Empty;
    public int Year;

    public static Batch Create(string name, int year)
    {
        var batch = new Batch {
            Name = name,
            Year = year
        };

        return batch;
    }
}