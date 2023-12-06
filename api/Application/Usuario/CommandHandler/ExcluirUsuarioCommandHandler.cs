using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class ExcluirUsuarioCommandHandler : IRequestHandler<ExcluirUsuarioCommand, UsuarioModel>
    {
        private readonly IUsuarioService _usuarioService;

        public ExcluirUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<UsuarioModel> Handle(ExcluirUsuarioCommand request, CancellationToken cancellationToken)
        {
            _usuarioService.ExcluirUsuario(request.Id);
            return Task.FromResult<UsuarioModel>(null);
        }
    }
}
