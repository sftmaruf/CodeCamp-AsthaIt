using MediatR;
using SMS.Domain.Entities;

namespace SMS.Application.Features.Batches.Commands.CreateBatch;

public record CreateBatchCommand : IRequest
{
    public string Name { get; set; } = string.Empty;
    public int Year { get; set; }
    public Guid DepartmentId { get; set; } = Guid.Empty;

    public Batch ToBatch()
    {
        var batch = Batch.Create(Name, Year, DepartmentId);

        return batch;
    }
}

