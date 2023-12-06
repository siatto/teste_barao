using api.Domain.Models;
using MediatR;

namespace api.Application.Localidade.Command
{
    public class LocalidadePorLogradouroCommand : IRequest<List<LocalidadeModel>>
    {
        public string logradouro { get; set; }
    }
}
