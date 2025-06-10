using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Querys.Motorcycles;

namespace MotosAluguel.Api.Controllers.MotorCycles;

[ApiController]
[Route("api/motos")]
public class MotorCycleQueryController : ControllerBase
{
    private readonly IMotorcycleQueryOrchestrator _motorcycleQueryOrchestrator;

    public MotorCycleQueryController(IMotorcycleQueryOrchestrator motorcycleQueryOrchestrator)
    {
        _motorcycleQueryOrchestrator = motorcycleQueryOrchestrator;
    }

    [HttpGet]
    public async Task<IActionResult> GetMotosByFilter([FromBody] MotorcyclesByFilterQuery filter)
    {
        var result = await _motorcycleQueryOrchestrator.GetMotorcyclesByFilter(filter);

        if (result.Success)
            return Ok(result.Data);

        else
            return BadRequest(result.Error);
    }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetMotorcycleById([FromRoute] string id)
    {
        var result = await _motorcycleQueryOrchestrator.GetMotorcycleByIdAsync(id);

        if (result.Success)
            return Ok(result.Data);

        else
            return BadRequest(result.Error);
    }
}
