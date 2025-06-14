using MotosAluguel.Application.Commands.Motorcycles;
using MotosAluguel.Application.Interfaces.Orchestrators.Motorcycles;
using MotosAluguel.Domain.Validators.Base;
using Serilog;

namespace MotosAluguel.Application.Orchestrators.Motorcycles;

public class MotorcycleInsertWithLoggerOrchestrator : IMotorcycleInsertOrchestrator
{
    private readonly IMotorcycleInsertOrchestrator _motorcycleInsertOrchestrator;

    private readonly ILogger _logger;

    public MotorcycleInsertWithLoggerOrchestrator(
        IMotorcycleInsertOrchestrator motorcycleInsertOrchestrator, 
        ILogger logger)
    {
        _motorcycleInsertOrchestrator = motorcycleInsertOrchestrator;
        _logger = logger;
    }


    public async Task<OperationResult> RunAsync(MotorcycleInsertCommand command)
    {
        try
        {
            _logger.Information("Starting motorcycle insertion process with data: {@Command}", command);

            var result = await _motorcycleInsertOrchestrator.RunAsync(command);

            _logger.Information("Motorcycle insertion process completed successfully with result: {@Result}", result);

            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "An error occurred during the motorcycle insertion process: {@Command}", command);

            return OperationResult.Fail("Ocorreu um erro interno");
        }
    }
}
