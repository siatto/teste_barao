using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class EstudanteLocalidadePorIdCommandHandler : IRequestHandler<EstudanteLocalidadePorIdCommand, EstudanteLocalidadeModel>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;

        public EstudanteLocalidadePorIdCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
        }

        public Task<EstudanteLocalidadeModel?> Handle(EstudanteLocalidadePorIdCommand request, CancellationToken cancellationToken)
        {
            EstudanteLocalidadeModel? estudanteLocalidade = _estudanteLocalidadeService.EstudanteLocalidadePorId(request.Id);
            return Task.FromResult(estudanteLocalidade);
        }
    }
}
