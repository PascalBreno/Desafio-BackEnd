using FluentValidation;
using MotosAluguel.Application.Commands.Riders;

namespace MotosAluguel.Application.Validators.Riders;

public class RiderInsertCommandValidator : AbstractValidator<RiderInsertCommand>
{
    public RiderInsertCommandValidator()
    {
        RuleFor(x => x.Identificador)
            .NotEmpty()
            .WithMessage("Identificador é obrigatório");

        RuleFor(x => x.Nome)
            .NotEmpty()
            .WithMessage("Nome é obrigatório");

        RuleFor(x => x.Cnpj)
            .NotEmpty()
            .WithMessage("Cnpj é obrigatório");

        RuleFor(x => x.Data_Nascimento)
            .NotEmpty()
            .WithMessage("Data_Nascimento é obrigatório");

        RuleFor(x => x.Numero_cnh)
            .NotEmpty()
            .WithMessage("Numero_cnh é obrigatório");

        RuleFor(x => x.Tipo_cnh)
            .NotEmpty()
            .WithMessage("Tipo_cnh é obrigatório");
    }
}
