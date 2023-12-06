using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class ExcluirEudanteCommandHandler : IRequestHandler<ExcluirEstudanteCommand, EstudanteModel>
    {
        private readonly IEstudanteService _estudanteService;

        public ExcluirEudanteCommandHandler(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        public Task<EstudanteModel> Handle(ExcluirEstudanteCommand request, CancellationToken cancellationToken)
        {
            _estudanteService.ExcluirEstudante(request.Id);
            return Task.FromResult<EstudanteModel>(null);
        }
    }
}
