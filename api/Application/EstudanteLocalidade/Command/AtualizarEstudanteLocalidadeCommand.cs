using api.Domain.Models;
using MediatR;

namespace api.Application.EstudanteLocalidade.Command
{
    public class AtualizarEstudanteLocalidadeCommand : IRequest<EstudanteLocalidadeModel>
    {
        public Guid Id { get; set; }
        public Guid EstudanteId { get; set; }
        public virtual EstudanteModel? Estudante { get; set; }
        public Guid LocalidadeId { get; set; }
        public virtual LocalidadeModel? Localidade { get; set; }
    }
}
