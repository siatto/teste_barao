using api.Domain.Models;
using MediatR;

namespace api.Application.Estudante.Command
{
    public class EstudantePorNomeCommand : IRequest<List<EstudanteModel>>
    {
        public required string NomeCompleto { get; set; }
    }
}
