using api.Domain.Models;
using MediatR;

namespace api.Application.Localidade.Command
{
    public class ListarLocalidadeCommand : IRequest<List<LocalidadeModel>> { }
}
