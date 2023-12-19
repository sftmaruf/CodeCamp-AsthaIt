using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Degrees.Commands.CreateDegree;

public record CreateDegreeCommand : IRequest
{
    public string Title { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; } = Guid.Empty;

    public Degree ToDegree(CreateDegreeCommand command)
    {
        var degree = Degree.Create(command.Title, command.DepartmentId);

        return degree;
    }
}