using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Commands.Rentals;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

namespace MotosAluguel.Api.Controllers.Rentals;

[ApiController]
[Route("api/locacao")]
public class RentalController : ControllerBase
{
    private readonly IRentalMotorcycleProcessOrchestrator _rentalMotorcycleProcessOrchestrator;

    private readonly IRentalSettlementOrchestrator _rentalSettlementOrchestrator;

    public RentalController(
        IRentalMotorcycleProcessOrchestrator rentalMotorcycleProcessOrchestrator,
        IRentalSettlementOrchestrator rentalSettlementOrchestrator)
    {
        _rentalMotorcycleProcessOrchestrator = rentalMotorcycleProcessOrchestrator;
        _rentalSettlementOrchestrator = rentalSettlementOrchestrator;
    }

    [HttpPost]
    public async Task<IActionResult> InsertRental([FromBody] RentalMotorcycleProcessCommand command)
    {
        var result = await _rentalMotorcycleProcessOrchestrator.RunAsync(command);

        if (result.Success)
            return Ok();

        else
            return StatusCode((int)result.HttpStatusCode, result.ErrorMessage);
    }

    [HttpPut("{Id}")]
    public async Task<IActionResult> CompleteRental([FromRoute] string Id, [FromBody] RentalSettlementCommand command)
    {
        var result = await _rentalSettlementOrchestrator.RunAsync(command);

        if (result.Success)
            return Ok(result.ErrorMessage);

        else
            return StatusCode((int)result.HttpStatusCode, result.ErrorMessage);
    }
}
