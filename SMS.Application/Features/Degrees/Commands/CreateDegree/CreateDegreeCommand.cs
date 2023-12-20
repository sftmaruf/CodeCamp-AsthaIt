using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Degrees.Commands.CreateDegree;

public record CreateDegreeCommand : IRequest
{
    public string Title { get; set; } = string.Empty;
    public Guid DepartmentId { get; set; } = Guid.Empty;

    public Degree ToDegree()
    {
        var degree = Degree.Create(Title, DepartmentId);

        return degree;
    }
}