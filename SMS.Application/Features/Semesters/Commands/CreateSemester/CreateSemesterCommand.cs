using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Semesters.Commands.CreateSemester;

public record CreateSemesterCommand : IRequest
{
    public int Month { get; set; }
    public int Year { get; set; }
    public int Duration { get; set; }

    public Semester ToSemester()
    {
        var semester = Semester.Create(Month, Year, Duration);

        return semester;;
    }
}