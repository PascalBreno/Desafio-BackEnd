using MotosAluguel.Domain.Entities.Rentals;
using MotosAluguel.Domain.Interfaces.Repositories.Rentals;
using Serilog;

namespace MotosAluguel.Infra.Repositories.Rentals;

public class RentalWriterRepositoryWithErrorHandler : IRentalWriterRepository
{
    private readonly IRentalWriterRepository _rentalWriterRepository;

    private readonly ILogger _logger;

    public RentalWriterRepositoryWithErrorHandler(
        IRentalWriterRepository rentalWriterRepository,
        ILogger logger)
    {
        _rentalWriterRepository = rentalWriterRepository;
        _logger = logger;
    }

    public async Task<Guid> InsertAsync(Rental rental)
    {
        try
        {
            _logger.Information("Iniciando o processo de inserção de aluguel com os dados: {@Rental}", rental);

            var result =  await _rentalWriterRepository.InsertAsync(rental);

            _logger.Information("Aluguel inserido com sucesso: {@RentalId}", result);

            return result;
        }
        catch (Exception ex)
        {
            _logger.Error(ex, "Erro ao inserir aluguel: {@Rental}", rental);

            throw new Exception("An error occurred while inserting the rental", ex);
        }
    }
}