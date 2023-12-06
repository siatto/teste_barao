using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class ListarEstudantesCommandHandler : IRequestHandler<ListarEstudantesCommand, List<EstudanteModel>>
    {
        private readonly IEstudanteService _estudanteService;

        public ListarEstudantesCommandHandler(IEstudanteService estudanteService)
        {
            _estudanteService = estudanteService;
        }

        public Task<List<EstudanteModel>> Handle(ListarEstudantesCommand request, CancellationToken cancellationToken)
        {
            List<EstudanteModel> estudantes = _estudanteService.ListarTodos();
            return Task.FromResult(estudantes);
        }
    }
}
