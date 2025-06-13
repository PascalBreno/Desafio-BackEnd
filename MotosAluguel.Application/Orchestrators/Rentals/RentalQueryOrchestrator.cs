using MotosAluguel.Application.Commons.Response.Rentals;
using MotosAluguel.Application.Interfaces.Orchestrators.Rentals;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Orchestrators.Rentals;

public class RentalQueryOrchestrator : IRentalQueryOrchestrator
{
    public Task<OperationResult<RentalResponse>> GetById(string id)
    {
        throw new NotImplementedException();
    }
}
