using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class EstudanteLocalidadePorEstudanteCommandHandler : IRequestHandler<EstudanteLocalidadePorEstudanteCommand, EstudanteLocalidadeModel>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;

        public EstudanteLocalidadePorEstudanteCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
        }

        public Task<EstudanteLocalidadeModel?> Handle(EstudanteLocalidadePorEstudanteCommand request, CancellationToken cancellationToken)
        {
            EstudanteLocalidadeModel? estudanteLocalidade = _estudanteLocalidadeService.EstudanteLocalidadePorEstudante(request.estudanteId);
            return Task.FromResult(estudanteLocalidade);
        }
    }
}
