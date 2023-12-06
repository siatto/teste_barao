using api.Domain.Models;
using MediatR;

namespace api.Application.Usuario.Command
{
    public class ExcluirUsuarioCommand : IRequest<UsuarioModel>
    {
        public Guid Id { get; set; }
    }
}
