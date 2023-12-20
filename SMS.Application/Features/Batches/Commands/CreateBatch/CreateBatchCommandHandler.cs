using MediatR;
using SMS.Application.Common.Interfaces;

namespace SMS.Application.Features.Batches.Commands.CreateBatch;

public class CreateBatchCommandHandler : IRequestHandler<CreateBatchCommand>
{
    private readonly IUnitOfWork _unitOfWork;

    public CreateBatchCommandHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task Handle(CreateBatchCommand request, CancellationToken cancellationToken)
    {

        var batch = request.ToBatch();
        // await _unitOfWork.Batches.GetByIdAsync(request.id);

        await _unitOfWork.Batches.AddAsync(batch);
        await _unitOfWork.SaveChangesAsync(cancellationToken);
    }
}