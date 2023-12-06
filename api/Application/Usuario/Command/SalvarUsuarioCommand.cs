using api.Domain.Models;
using MediatR;

namespace api.Application.Usuario.Command
{
    public class SalvarUsuarioCommand : IRequest<UsuarioModel>
    {
        public Guid Id { get; set; }
        public string Login { get; set; }
        public required string Senha { get; set; }
    }
}
