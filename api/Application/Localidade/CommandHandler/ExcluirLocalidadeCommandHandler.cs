using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class ExcluirLocalidadeCommandHandler : IRequestHandler<ExcluirLocalidadeCommand, LocalidadeModel>
    {
        private readonly ILocalidadeService _localidadeService;

        public ExcluirLocalidadeCommandHandler(ILocalidadeService localidadeService)
        {
            _localidadeService = localidadeService;
        }

        public Task<LocalidadeModel> Handle(ExcluirLocalidadeCommand request, CancellationToken cancellationToken)
        {
            _localidadeService.ExcluirLocalidade(request.Id);
            return Task.FromResult<LocalidadeModel>(null);
        }
    }
}
