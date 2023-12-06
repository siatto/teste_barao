using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories.Interfaces;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class EstudantePorNomeCommandHandler : IRequestHandler<EstudantePorNomeCommand, List<EstudanteModel>>
    {
        private readonly IEstudanteService _estudanteService;

        public EstudantePorNomeCommandHandler(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        public Task<List<EstudanteModel>> Handle(EstudantePorNomeCommand request, CancellationToken cancellationToken)
        {
            List<EstudanteModel> estudantes = _estudanteService.EstudantePorNome(request.NomeCompleto);
            return Task.FromResult(estudantes);
        }
    }
}
