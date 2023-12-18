using MediatR;
using SMS.Application.Common.Interfaces;

namespace SMS.Application.Features.Courses.Commands;

public class CreateCourseCommandHandler : IRequestHandler<CreateCourseCommand>
{
    private IUnitOfWork _unitOfWork;

    public CreateCourseCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateCourseCommand request, CancellationToken cancellationToken)
    {
        var course = request.ToCourse(request);

        await _unitOfWork.Courses.AddAsync(course);
    }
}