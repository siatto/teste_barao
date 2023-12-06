using api.Application.Estudante.Command;
using FluentValidation;

namespace api.Application.Estudante.Validation
{
    public class SalvarEstudanteCommandValidator : AbstractValidator<SalvarEstudanteCommand>
    {
        public SalvarEstudanteCommandValidator()
        {
            RuleFor(estudante => estudante.NomeCompleto).NotEmpty().WithMessage("O nome do estudante é obrigatório.");
            RuleFor(estudante => estudante.DataNascimento).NotNull().WithMessage("A data de nascimento do estudante é obrigatória.");
        }
    }
}
