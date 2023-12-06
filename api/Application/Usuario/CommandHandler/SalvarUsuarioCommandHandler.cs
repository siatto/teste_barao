using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class SalvarUsuarioCommandHandler : IRequestHandler<SalvarUsuarioCommand, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;
        private readonly IValidator<SalvarUsuarioCommand> _usuarioValidator;

        public SalvarUsuarioCommandHandler(IUsuarioService usuarioService, IValidator<SalvarUsuarioCommand> usuarioValidator)
        {
            _usuarioService = usuarioService;
            _usuarioValidator = usuarioValidator;
        }

        public Task<UsuarioModel> Handle(SalvarUsuarioCommand request, CancellationToken cancellationToken)
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

            _usuarioService.SalvarUsuario(usuario);

            return Task.FromResult(usuario);
        }
    }
}
