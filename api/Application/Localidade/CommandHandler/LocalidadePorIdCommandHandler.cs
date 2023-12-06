using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class LocalidadePorIdCommandHandler : IRequestHandler<LocalidadePorIdCommand, LocalidadeModel>
    {
        private readonly ILocalidadeService _localidadeService;

        public LocalidadePorIdCommandHandler(ILocalidadeService localidadeService)
        {
            _localidadeService = localidadeService;
        }

        public Task<LocalidadeModel?> Handle(LocalidadePorIdCommand request, CancellationToken cancellationToken)
        {
            LocalidadeModel? localidade = _localidadeService.LocalidadePorId(request.Id);
            return Task.FromResult(localidade);
        }
    }
}
