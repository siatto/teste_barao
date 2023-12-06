using api.Domain.Models;
using MediatR;

namespace api.Application.Estudante.Command
{
    public class SalvarEstudanteCommand : IRequest<EstudanteModel>
    {
        public Guid Id { get; set; }
        public required string NomeCompleto { get; set; }
        public DateTime DataNascimento { get; set; }
        public LocalidadeModel? Localidade { get; set; }
    }
}
