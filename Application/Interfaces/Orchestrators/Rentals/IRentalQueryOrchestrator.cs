using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Commons.Response.Rentals;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

public interface IRentalQueryOrchestrator
{
    Task<OperationResult<RentalResponse>> GetById(string id);
}
