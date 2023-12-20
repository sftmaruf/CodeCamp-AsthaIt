using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Batches.Commands.CreateBatch;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]/[action]")]
public class BatchController : ControllerBase
{
    private readonly ISender _sender;

    public BatchController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task CreateBatch(CreateBatchCommand command)
    {
        await _sender.Send(command);
    }
}