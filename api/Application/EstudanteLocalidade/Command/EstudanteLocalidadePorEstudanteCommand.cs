using api.Domain.Models;
using MediatR;

namespace api.Application.EstudanteLocalidade.Command
{
    public class EstudanteLocalidadePorEstudanteCommand : IRequest<EstudanteLocalidadeModel>
    {
        public Guid estudanteId { get; set; }
    }
}
