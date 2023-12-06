using api.Domain.Models;
using MediatR;

namespace api.Application.EstudanteLocalidade.Command
{
    public class ListarEstudanteLocalidadeCommand : IRequest<List<EstudanteLocalidadeModel>> { }
}
