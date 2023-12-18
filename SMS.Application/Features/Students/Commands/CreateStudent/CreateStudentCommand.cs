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
    public string Department { get; set; } = string.Empty;
    public string Degree { get; set; } = string.Empty;

    public Student ToStudent(CreateStudentCommand command)
    {
        var student = Student.Create(command.ClassId, command.FirstName, command.MiddleName, command.LastName,
            command.JoiningBatch, command.Department, command.Degree);

        return student;
    }
}