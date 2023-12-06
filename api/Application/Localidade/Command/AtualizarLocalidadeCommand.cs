using api.Domain.Models;
using MediatR;

namespace api.Application.Localidade.Command
{
    public class AtualizarLocalidadeCommand : IRequest<LocalidadeModel>
    {
        public Guid Id { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Logradouro { get; set; }
        public string Cep { get; set; }
    }
}
