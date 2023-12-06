using api.Application.Usuario.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Usuario.CommandHandler
{
    public class ListarUsuarioCommandHandler : IRequestHandler<ListarUsuarioCommand, List<UsuarioModel>>
    {
        private readonly IUsuarioService _usuarioService;

        public ListarUsuarioCommandHandler(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        public Task<List<UsuarioModel>> Handle(ListarUsuarioCommand request, CancellationToken cancellationToken)
        {
            List<UsuarioModel> usuarios = _usuarioService.ListarTodos();
            return Task.FromResult(usuarios);
        }
    }
}
