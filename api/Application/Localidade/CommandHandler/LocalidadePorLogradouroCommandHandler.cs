using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class LocalidadePorLogradouroCommandHandler : IRequestHandler<LocalidadePorLogradouroCommand, List<LocalidadeModel>>
    {
        private readonly ILocalidadeService _localidadeService;

        public LocalidadePorLogradouroCommandHandler(ILocalidadeService localidadeService)
        {
            _localidadeService = localidadeService;
        }

        public Task<List<LocalidadeModel>> Handle(LocalidadePorLogradouroCommand request, CancellationToken cancellationToken)
        {
            List<LocalidadeModel> localidades = _localidadeService.LocalidadePorLogradouro(request.logradouro);
            return Task.FromResult(localidades);
        }
    }
}
