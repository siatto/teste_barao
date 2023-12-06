using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class ListarLocalidadeCommandHandler : IRequestHandler<ListarLocalidadeCommand, List<LocalidadeModel>>
    {
        private readonly ILocalidadeService _localidadeService;

        public ListarLocalidadeCommandHandler(ILocalidadeService localidadeService)
        {
            _localidadeService = localidadeService;
        }

        public Task<List<LocalidadeModel>> Handle(ListarLocalidadeCommand request, CancellationToken cancellationToken)
        {
            List<LocalidadeModel> localidades = _localidadeService.ListarTodos();
            return Task.FromResult(localidades);
        }
    }
}
