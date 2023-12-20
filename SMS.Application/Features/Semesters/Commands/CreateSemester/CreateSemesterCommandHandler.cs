using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Semesters.Commands.CreateSemester;

public record CreateSemesterCommandHandler : IRequestHandler<CreateSemesterCommand>
{
    public readonly IUnitOfWork _unitOfWork;

    public CreateSemesterCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateSemesterCommand request, CancellationToken cancellationToken)
    {
        var semester = request.ToSemester();

        await _unitOfWork.Semesters.AddAsync(semester);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}