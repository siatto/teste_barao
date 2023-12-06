using api.Domain.Models;
using MediatR;

namespace api.Application.Estudante.Command
{
    public class ListarEstudantesCommand : IRequest<List<EstudanteModel>> { }
}
