using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Students.Commands.CreateStudent;

public record CreateStudentCommand : IRequest
{
    public string ClassId { get; set; } = string.Empty;
    public string FirstName { get; set;} = string.Empty;
    public string MiddleName { get; set;} = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string JoiningBatch { get; set; } = string.Empty;
    public Guid BatchId { get; set; } = Guid.Empty;

    public Student ToStudent()
    {
        var student = Student.Create(ClassId, FirstName, MiddleName, LastName,
            JoiningBatch, BatchId);

        return student;
    }
}