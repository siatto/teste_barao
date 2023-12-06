using api.Domain.Models;
using MediatR;

namespace api.Application.Localidade.Command
{
    public class LocalidadePorIdCommand : IRequest<LocalidadeModel>
    {
        public Guid Id { get; set; }
    }
}
