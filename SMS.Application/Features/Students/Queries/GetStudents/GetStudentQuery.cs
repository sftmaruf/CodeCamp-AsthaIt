using MediatR;

namespace SMS.Application.Features.Students.Queries.GetStudents;

public record GetStudentsQuery : IRequest<List<string>>;