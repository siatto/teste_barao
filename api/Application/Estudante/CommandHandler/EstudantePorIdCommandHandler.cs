using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class EstudantePorIdCommandHandler : IRequestHandler<EstudantePorIdCommand, EstudanteModel>
    {
        private readonly IEstudanteService _estudanteService;

        public EstudantePorIdCommandHandler(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        public Task<EstudanteModel?> Handle(EstudantePorIdCommand request, CancellationToken cancellationToken)
        {
            EstudanteModel? estudante = _estudanteService.EstudantePorId(request.Id);
            return Task.FromResult(estudante);
        }
    }
}
