using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Instructors.Commands.CreateInstructor;

public record CreateInstructorCommand : IRequest
{
    public string Name { get; set; } = string.Empty;

    public Instructor ToInstructor()
    {
        var instructor = Instructor.Create(Name);

        return instructor;
    }
}