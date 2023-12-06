using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class UsuarioPorIdCommandHandler : IRequestHandler<UsuarioPorIdCommand, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioPorIdCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<UsuarioModel?> Handle(UsuarioPorIdCommand request, CancellationToken cancellationToken)
        {
            UsuarioModel? usuario = _usuarioService.UsuarioPorId(request.Id);
            return Task.FromResult(usuario);
        }
    }
}
