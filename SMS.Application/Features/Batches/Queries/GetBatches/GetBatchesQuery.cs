using MediatR;
using SMS.Domain.DTOs;

namespace SMS.Application.Features.Batches.Queries.GetBatches;

public record GetBatchesQuery : IRequest<List<BatchDto>>;