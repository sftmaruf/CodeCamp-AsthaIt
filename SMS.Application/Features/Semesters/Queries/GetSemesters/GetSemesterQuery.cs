using MediatR;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Semesters.Queries.GetSemesters;

public record GetSemestersQuery : IRequest<IReadOnlyList<SemesterDto>>
{

}