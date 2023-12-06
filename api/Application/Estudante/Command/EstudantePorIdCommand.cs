using api.Domain.Models;
using MediatR;

namespace api.Application.Estudante.Command
{
    public class EstudantePorIdCommand : IRequest<EstudanteModel>
    {
        public Guid Id { get; set; }
    }
}
