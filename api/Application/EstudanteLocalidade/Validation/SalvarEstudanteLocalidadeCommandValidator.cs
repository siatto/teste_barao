using api.Application.EstudanteLocalidade.Command;
using FluentValidation;

namespace api.Application.EstudanteLocalidade.Validation
{
    public class SalvarEstudanteLocalidadeCommandValidator : AbstractValidator<SalvarEstudanteLocalidadeCommand>
    {
        public SalvarEstudanteLocalidadeCommandValidator()
        {
            RuleFor(estudanteLocalidade => estudanteLocalidade.EstudanteId).NotEmpty().WithMessage("O ID do estudante é obrigatório.");
            RuleFor(estudanteLocalidade => estudanteLocalidade.LocalidadeId).NotEmpty().WithMessage("O ID da localidade é obrigatória.");
        }
    }
}
