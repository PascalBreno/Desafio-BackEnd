using MotosAluguel.Domain.Interfaces.Repositories.Riders;
using MotosAluguel.Domain.Interfaces.Validators.Riders;
using MotosAluguel.Domain.Validators.Base;
using System.Net;

namespace MotosAluguel.Domain.Validators.Riders.UpdateCnh;

public class RiderUpdateCnhExistValidator : IRiderUpdateCnhValidator
{
    private readonly IRiderUpdateCnhValidator _validator;

    private readonly IRiderReaderRepository _riderReaderRepository;
    public RiderUpdateCnhExistValidator(
        IRiderUpdateCnhValidator nextValidator,
        IRiderReaderRepository riderReaderRepository)
    {
        _validator = nextValidator;
        _riderReaderRepository = riderReaderRepository;
    }

    public async Task<OperationResult> ValidateAsync(string id, string imageCnh)
    {
        var operationResult = await _validator.ValidateAsync(id, imageCnh);

        if (operationResult.Success)
        {
            var riderExists = await _riderReaderRepository.ExistById(id);

            if (!riderExists)
                return OperationResult.Fail("Entregador não encontrado.", HttpStatusCode.NotFound);
        }

        return operationResult;
    }
}
