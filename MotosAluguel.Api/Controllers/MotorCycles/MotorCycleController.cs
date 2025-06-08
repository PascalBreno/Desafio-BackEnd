using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Domain.Entities.MotorCycles;
using MotosAluguel.Domain.Interfaces.Repositories;

namespace MotosAluguel.Api.Controllers.MotorCycles;

[ApiController]
[Route("api/[controller]")]
public class MotorCycleController : ControllerBase
{
    private readonly IMotorCycleWriterRepository _repository;

    public MotorCycleController(IMotorCycleWriterRepository repository)
    {
        _repository = repository;
    }

    [HttpPost]
    public async Task<IActionResult> InsertMotorCycle([FromBody] MotorCycle motorCycle)
    {
        if (motorCycle == null)
            return BadRequest("Dados inválidos.");

        var insertedId = await _repository.InsertAsync(motorCycle);

        return CreatedAtAction(nameof(insertedId), new { id = insertedId }, motorCycle);
    }
}
