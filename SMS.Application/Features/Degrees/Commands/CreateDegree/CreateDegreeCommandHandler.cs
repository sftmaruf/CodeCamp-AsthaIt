using MediatR;
using SMS.Application.Common.Interfaces;

namespace SMS.Application.Features.Degrees.Commands.CreateDegree;

public class CreateDegreeCommandHandler : IRequestHandler<CreateDegreeCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateDegreeCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateDegreeCommand request, CancellationToken cancellationToken)
    {
        var degree = request.ToDegree();

        await _unitOfWork.Degrees.AddAsync(degree);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}