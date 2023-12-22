using MediatR;
using SMS.Application.Common.Interfaces;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Batches.Queries.GetBatches;

public class GetBatchesQueryHandler : IRequestHandler<GetBatchesQuery, List<BatchDto>>
{
    private readonly IUnitOfWork _unitOfWork;

    public GetBatchesQueryHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public async Task<List<BatchDto>> Handle(GetBatchesQuery request, CancellationToken cancellationToken)
    {
        var batches = await _unitOfWork.Batches.GetAllAsync("Department");

        var batchDtos = new List<BatchDto>();
        foreach(var batch in batches)
        {
            batchDtos.Add(new() {
                Id = batch.Id,
                Name = batch.Name,
                Year = batch.Year,
                DepartmentName = batch.Department?.Name!
            });
        }

        return batchDtos;
    }
}