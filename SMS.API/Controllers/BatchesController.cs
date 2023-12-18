using MediatR;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Batches.Commands.CreateBatch;

namespace SMS.API.Controllers;

[ApiController]
[Route("api/v1/[controller]")]
public class BatchesController : ControllerBase
{
    private readonly ISender _sender;

    public BatchesController(ISender sender)
    {
        _sender = sender;
    }

    [HttpPost]
    public async Task CreateTask(CreateBatchCommand command)
    {
        await _sender.Send(command);
    }
}