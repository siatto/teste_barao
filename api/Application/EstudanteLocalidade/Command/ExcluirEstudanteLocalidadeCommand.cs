using api.Domain.Models;
using MediatR;

namespace api.Application.EstudanteLocalidade.Command
{
    public class ExcluirEstudanteLocalidadeCommand : IRequest<EstudanteLocalidadeModel>
    {
        public Guid Id { get; set; }
    }
}
