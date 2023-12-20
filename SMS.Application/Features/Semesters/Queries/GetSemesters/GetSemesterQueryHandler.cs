using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Semesters.Queries.GetSemesters;

public class GetSemestersQueryHandler : IRequestHandler<GetSemestersQuery, IReadOnlyList<SemesterDto>>
{
    private IUnitOfWork _unitOfWork;

    public GetSemestersQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<IReadOnlyList<SemesterDto>> Handle(GetSemestersQuery request, CancellationToken cancellationToken)
    {
        var semesters = await _unitOfWork.Semesters.GetAllAsync();

        var semesterDTOs = new List<SemesterDto>();
        foreach(var semester in semesters)
        {
            semesterDTOs.Add(new() {
                Id = semester.Id,
                Month = semester.Month,
                Year = semester.Year,
                Duration = semester.Duration
            });
        }

        return semesterDTOs;
    }
}