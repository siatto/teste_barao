using api.Domain.Models;
using MediatR;

namespace api.Application.Usuario.Command
{
    public class UsuarioPorLoginSenhaCommand : IRequest<UsuarioModel>
    {
        public string Login { get; set; }
        public required string Senha { get; set; }
    }
}
