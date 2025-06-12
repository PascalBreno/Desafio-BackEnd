using MotosAluguel.Application.Commands.Riders;
using MotosAluguel.Application.Commons;
using MotosAluguel.Application.Interfaces.Orchestrators.Riders;

namespace MotosAluguel.Application.Orchestrators.Riders;

public class RiderInsertCnhOrchestrator : IRiderInsertCnhOrchestrator
{
    public Task<OperationResult<string>> RunAsync(RiderInsertCommand command)
    {
        throw new NotImplementedException();
    }

    public Task<OperationResult<string>> RunAsync(string id, RiderInsertCnhCommand command)
    {
        throw new NotImplementedException();
    }
}
