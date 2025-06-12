using Microsoft.AspNetCore.Mvc;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

namespace MotosAluguel.Api.Controllers.Rentals;

[ApiController]
[Route("api/locacao")]
public class RentalQueryController : ControllerBase
{
    private readonly IRentalQueryOrchestrator _rentalQueryOrchestrator;

    public RentalQueryController(IRentalQueryOrchestrator rentalQueryOrchestrator)
    {
        _rentalQueryOrchestrator = rentalQueryOrchestrator;
    }

    [HttpGet("{rentalId}")]
    public async Task<IActionResult> GetRentalDetails([FromRoute] string rentalId)
    {
        var result = await _rentalQueryOrchestrator.GetById(rentalId);

        if (result.Success)

            if(result.Data is null)
                return NotFound("Locação não encontrada");

            else
                return Ok(result.Data);

        else
            return NotFound(result.Message);
    }
}
