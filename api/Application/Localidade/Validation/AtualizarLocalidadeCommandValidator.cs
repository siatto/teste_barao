using api.Application.Localidade.Command;
using FluentValidation;

namespace api.Application.Localidade.Validation
{
    public class AtualizarLocalidadeCommandValidator : AbstractValidator<AtualizarLocalidadeCommand>
    {
        public AtualizarLocalidadeCommandValidator()
        {
            RuleFor(localidade => localidade.Cidade).NotEmpty().WithMessage("A cidade é obrigatória.");
            RuleFor(localidade => localidade.Estado).NotEmpty().WithMessage("O estado é obrigatório.");
            RuleFor(localidade => localidade.Cep).NotEmpty().WithMessage("O cep é obrigatório.");
            RuleFor(localidade => localidade.Logradouro).NotEmpty().WithMessage("O logradouro é obrigatório.");
        }
    }
}
