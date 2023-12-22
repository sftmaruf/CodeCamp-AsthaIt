namespace SMS.Domain.Entities;

public class Credential
{
    public Guid Id { get; set; }
    public string Password  { get; set; } = string.Empty;
    public Guid StudentId { get; set; } = Guid.Empty;
    public Student? Student { get; set; }
}