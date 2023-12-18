using MediatR;

namespace SMS.Application.Features.Students.Queries.GetStudents;

public class GetStudentsQueryHandler : IRequestHandler<GetStudentsQuery, List<string>>
{
    public Task<List<string>> Handle(GetStudentsQuery request, CancellationToken cancellationToken)
    {
        var list = new List<string> {
            "Shafayet", "Maruf"
        };

        return Task.FromResult(list);
    }
}