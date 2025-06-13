using MotosAluguel.Application.Commons.Response.Motorcycles;
using MotosAluguel.Application.Querys.Motorcycles;
using MotosAluguel.Domain.Validators.Base;

namespace MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;

public interface IMotorcycleQueryOrchestrator
{
    Task<OperationResult<MotorcycleResponse>> 
        GetMotorcycleByIdAsync(string id);


    Task<OperationResult<IEnumerable<MotorcycleResponse>>> 
        GetMotorcyclesByFilter(MotorcyclesByFilterQuery filter);
}
