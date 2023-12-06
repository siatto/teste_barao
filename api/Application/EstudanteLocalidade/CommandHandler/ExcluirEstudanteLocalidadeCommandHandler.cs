using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class ExcluirEstudanteLocalidadeCommandHandler : IRequestHandler<ExcluirEstudanteLocalidadeCommand, EstudanteLocalidadeModel>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;

        public ExcluirEstudanteLocalidadeCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
        }

        public Task<EstudanteLocalidadeModel> Handle(ExcluirEstudanteLocalidadeCommand request, CancellationToken cancellationToken)
        {
            _estudanteLocalidadeService.ExcluirEstudanteLocalidade(request.Id);
            return Task.FromResult<EstudanteLocalidadeModel>(null);
        }
    }
}
