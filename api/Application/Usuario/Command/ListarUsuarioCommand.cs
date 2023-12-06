using api.Domain.Models;
using MediatR;

namespace api.Application.Usuario.Command
{
    public class ListarUsuarioCommand : IRequest<List<UsuarioModel>> { }
}
