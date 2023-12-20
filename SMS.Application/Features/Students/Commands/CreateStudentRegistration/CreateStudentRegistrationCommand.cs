using MediatR;

namespace SMS.Application.Features.Students.Commands.CreateStudentRegistration;

public record CreateStudentRegistrationCommand : IRequest
{
    public Guid StudentId { get; set; } = Guid.Empty;
    public Guid SemesterId { get; set; } = Guid.Empty;
    public List<Guid> CourseIds { get; set; } = new();
}