using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Departments.Commands;

public record CreateDepartmentCommand : IRequest
{
    public string Name { get; set; } = string.Empty;

    public Department ToDepartment()
    {
        var department = Department.Create(Name);
        return department;
    }
}