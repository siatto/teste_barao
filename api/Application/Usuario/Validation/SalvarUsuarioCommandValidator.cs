using api.Application.Usuario.Command;
using FluentValidation;

namespace api.Application.Usuario.Validation
{
    public class SalvarUsuarioCommandValidator : AbstractValidator<SalvarUsuarioCommand>
    {
        public SalvarUsuarioCommandValidator()
        {
            RuleFor(usuario => usuario.Login).NotEmpty().WithMessage("O login é obrigatório.");
            RuleFor(usuario => usuario.Senha).NotEmpty().WithMessage("A senha é obrigatória.");
        }
    }
}
