using api.Domain.Models;
using MediatR;

namespace api.Application.EstudanteLocalidade.Command
{
    public class EstudanteLocalidadePorIdCommand : IRequest<EstudanteLocalidadeModel>
    {
        public Guid Id { get; set; }
    }
}
