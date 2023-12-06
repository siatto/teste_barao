using api.Domain.Models;
using MediatR;

namespace api.Application.Localidade.Command
{
    public class ExcluirLocalidadeCommand : IRequest<LocalidadeModel>
    {
        public Guid Id { get; set; }
    }
}
