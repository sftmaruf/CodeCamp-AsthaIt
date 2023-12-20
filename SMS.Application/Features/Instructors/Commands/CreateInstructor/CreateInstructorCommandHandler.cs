using MediatR;
using SMS.Application.Common.Interfaces;

namespace SMS.Application.Features.Instructors.Commands.CreateInstructor;

public record CreateInstructorCommandHandler : IRequestHandler<CreateInstructorCommand>
{
    private IUnitOfWork _unitOfWork;

    public CreateInstructorCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateInstructorCommand request, CancellationToken cancellationToken)
    {
        var instructor = request.ToInstructor();

        await _unitOfWork.Instructors.AddAsync(instructor);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}