using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class UsuarioPorLoginSenhaCommandHandler : IRequestHandler<UsuarioPorLoginSenhaCommand, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioPorLoginSenhaCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<UsuarioModel> Handle(UsuarioPorLoginSenhaCommand request, CancellationToken cancellationToken)
        {
            UsuarioModel usuarios = _usuarioService.UsuarioPorLoginSenha(request.Login, request.Senha);
            return Task.FromResult(usuarios);
        }
    }
}
