using api.Application.Estudante.Command;
using FluentValidation;

namespace api.Application.Estudante.Validation
{
    public class AtualizarEstudanteCommandValidator : AbstractValidator<AtualizarEstudanteCommand>
    {
        public AtualizarEstudanteCommandValidator()
        {
            RuleFor(estudante => estudante.NomeCompleto).NotEmpty().WithMessage("O nome do estudante é obrigatório.");
            RuleFor(estudante => estudante.DataNascimento).NotNull().WithMessage("A data de nascimento do estudante é obrigatória.");
        }
    }
}
