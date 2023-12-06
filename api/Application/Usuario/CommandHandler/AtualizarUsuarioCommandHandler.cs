using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class AtualizarUsuarioCommandHandler : IRequestHandler<AtualizarUsuarioCommand, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IValidator<AtualizarUsuarioCommand> _usuarioValidator;

        public AtualizarUsuarioCommandHandler(IUsuarioService usuarioService, IValidator<AtualizarUsuarioCommand> usuarioValidator)
        {
            _usuarioService = usuarioService;
            _usuarioValidator = usuarioValidator;
        }

        public Task<UsuarioModel> Handle(AtualizarUsuarioCommand request, CancellationToken cancellationToken)
        {
            var commandValidado = _usuarioValidator.Validate(request);

            if (!commandValidado.IsValid)
            {
                throw new ValidationException(commandValidado.Errors);
            }

            var usuario = new UsuarioModel
            {
                Id = request.Id,
                Login = request.Login,
                Senha = request.Senha
            };

            _usuarioService.AtualizarUsuario(usuario);

            return Task.FromResult(usuario);
        }
    }
}
