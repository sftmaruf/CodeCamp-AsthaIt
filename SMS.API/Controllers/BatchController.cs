using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SMS.Application.Features.Batches.Commands.CreateBatch;
using SMS.Application.Features.Batches.Queries.GetBatches;

namespace SMS.API.Controllers;

[Authorize]
[ApiController]
[Route("api/v1/[controller]/[action]")]
public class BatchController : ControllerBase
{
    private readonly ISender _sender;

    public BatchController(ISender sender)
    {
        _sender = sender;
    }

    [HttpGet]
    [AllowAnonymous]
    public async Task<ActionResult> GetBatches()
    {
        var query = new GetBatchesQuery();
        var response = await _sender.Send(query);

        return Ok(response);
    }

    [HttpPost]
    public async Task CreateBatch(CreateBatchCommand command)
    {
        await _sender.Send(command);
    }
}