using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;

namespace MotosAluguel.Api.Controllers.MotorCycles;

[ApiController]
[Route("api/motos")]
public class MotorCycleController : ControllerBase
{
    private readonly IMotorcycleInsertOrchestrator _motorcycleInsertOrchestrator;

    private readonly IMotorcycleDeleteOrchestrator _motorcycleDeleteOrchestrator;

    private readonly IMotorcycleUpdateOrchestrator _motorcycleUpdateOrchestrator;

    public MotorCycleController(
        IMotorcycleInsertOrchestrator motorcycleInsertOrchestrator,
        IMotorcycleDeleteOrchestrator motorcycleDeleteOrchestrator,
        IMotorcycleUpdateOrchestrator motorcycleUpdateOrchestrator)
    {
        _motorcycleInsertOrchestrator = motorcycleInsertOrchestrator;
        _motorcycleDeleteOrchestrator = motorcycleDeleteOrchestrator;
        _motorcycleUpdateOrchestrator = motorcycleUpdateOrchestrator;
    }

    [HttpPost]
    public async Task<IActionResult> InsertMotorCycle([FromBody] MotorcycleInsertCommand command)
    {
        var result = await _motorcycleInsertOrchestrator.RunAsync(command);

        if(result.Success)
            return Created();

        else
            return BadRequest(result.Message);    
    }

    [HttpDelete("{Id}")]
    public async Task<IActionResult> DeleteMotorCycleById([FromRoute] string Id)
    {
        var result = await _motorcycleDeleteOrchestrator.RunAsync(Id);

        if (result.Success)
            return Ok();

        else
            return BadRequest(result.Message);
    }

    [HttpPut("{Id}/placa")]
    public async Task<IActionResult> UpdateMotorCyclePlaca(
        string Id,
        [FromBody] MotorcycleUpdatePlateCommand command)
    {
        var result = await _motorcycleUpdateOrchestrator.UpdatePlateAsync(Id, command);

        if (result.Success)
            return Ok(result.Message);

        else
            return BadRequest(result.Message);
    }
}
