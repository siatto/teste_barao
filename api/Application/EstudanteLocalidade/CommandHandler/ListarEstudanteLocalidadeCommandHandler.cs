using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class ListarEstudanteLocalidadeCommandHandler : IRequestHandler<ListarEstudanteLocalidadeCommand, List<EstudanteLocalidadeModel>>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;

        public ListarEstudanteLocalidadeCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
        }

        public Task<List<EstudanteLocalidadeModel>> Handle(ListarEstudanteLocalidadeCommand request, CancellationToken cancellationToken)
        {
            List<EstudanteLocalidadeModel> estudantesLocalidades = _estudanteLocalidadeService.ListarTodos();
            return Task.FromResult(estudantesLocalidades);
        }
    }
}
