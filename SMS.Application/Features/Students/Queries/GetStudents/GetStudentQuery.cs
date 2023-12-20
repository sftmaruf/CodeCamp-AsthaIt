using MediatR;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Students.Queries.GetStudents;

public record GetStudentsQuery : IRequest<IReadOnlyList<StudentDto>>;