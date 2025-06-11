using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

namespace MotosAluguel.Api.Controllers.MotorCycles;

[ApiController]
[Route("api/motos")]
public class MotorCycleController : ControllerBase
{
    private readonly IMotorcycleInsertOrchestrator _motorcycleInsertOrchestrator;

    private readonly IMotorcycleDeleteOrchestrator _motorcycleDeleteOrchestrator;

    public MotorCycleController(
        IMotorcycleInsertOrchestrator motorcycleInsertOrchestrator,
        IMotorcycleDeleteOrchestrator motorcycleDeleteOrchestrator)
    {
        _motorcycleInsertOrchestrator = motorcycleInsertOrchestrator;
        _motorcycleDeleteOrchestrator = motorcycleDeleteOrchestrator;
    }

    [HttpPost]
    public async Task<IActionResult> InsertMotorCycle([FromBody] MotorcycleInsertCommand command)
    {
        var result = await _motorcycleInsertOrchestrator.RunAsync(command);

        if(result.Success)
            return Created();

        else
            return BadRequest(result.Error);    
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteMotorCycleById([FromRoute] string id)
    {
        var result = await _motorcycleDeleteOrchestrator.RunAsync(id);

        if (result.Success)
            return Created();

        else
            return BadRequest(result.Error);
    }
}
