using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Batches.Commands.CreateBatch;

public record CreateBatchCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }

    public Batch ToBatch(CreateBatchCommand request)
    {
        var batch = Batch.Create(request.Name, request.Year);

        return batch;
    }
}

