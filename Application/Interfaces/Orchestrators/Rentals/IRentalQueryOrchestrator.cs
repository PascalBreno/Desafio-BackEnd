using MotosAluguel.Application.Commons.Response.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Rentals;

public interface IRentalQueryOrchestrator
{
    Task<OperationResult<RentalResponse>> GetById(string id);
}
