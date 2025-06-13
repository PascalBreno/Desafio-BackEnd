using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;

namespace MotosAluguel.Api.Controllers.Riders;

[ApiController]
[Route("api/entregadores")]
public class RiderController : ControllerBase
{
    private readonly IRiderInsertOrchestrator _riderInsertOrchestrator;

    private readonly IRiderInsertCnhOrchestrator _riderInsertCnhOrchestrator;

    public RiderController(
        IRiderInsertOrchestrator riderInsertOrchestrator,
        IRiderInsertCnhOrchestrator riderInsertCnhOrchestrator)
    {
        _riderInsertOrchestrator = riderInsertOrchestrator;
        _riderInsertCnhOrchestrator = riderInsertCnhOrchestrator;
    }

    [HttpPost]
    public async Task<IActionResult> InsertRider([FromBody] RiderInsertCommand command)
    {
        var result = await _riderInsertOrchestrator.RunAsync(command);
            
        if (result.Success)
            return Created();

        else
            return StatusCode((int)result.HttpStatusCode, result.ErrorMessage);

    }

    [HttpPost("{id}/cnh")]
    public async Task<IActionResult> InsertRiderCnh([FromRoute] string id, [FromBody] RiderInsertCnhCommand command)
    {
        var result = await _riderInsertCnhOrchestrator.RunAsync(id, command);

        if (result.Success)
            return Ok();

        else
            return StatusCode((int)result.HttpStatusCode, result.ErrorMessage);
    }
}
