using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class AtualizarEstudanteLocalidadeCommandHandler : IRequestHandler<AtualizarEstudanteLocalidadeCommand, EstudanteLocalidadeModel>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;
        private readonly IValidator<AtualizarEstudanteLocalidadeCommand> _estudanteLocalidadeValidator;

        public AtualizarEstudanteLocalidadeCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService, IValidator<AtualizarEstudanteLocalidadeCommand> estudanteLocalidadeValidator)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
            _estudanteLocalidadeValidator = estudanteLocalidadeValidator;
        }

        public Task<EstudanteLocalidadeModel> Handle(AtualizarEstudanteLocalidadeCommand request, CancellationToken cancellationToken)
        {
            var commandValidado = _estudanteLocalidadeValidator.Validate(request);

            if (!commandValidado.IsValid)
            {
                throw new ValidationException(commandValidado.Errors);
            }

            var estudanteLocalidade = new EstudanteLocalidadeModel
            {
                Id = request.Id,
                EstudanteId = request.EstudanteId,
                Estudante = request.Estudante,
                LocalidadeId = request.LocalidadeId,
                Localidade = request.Localidade
            };

            _estudanteLocalidadeService.AtualizarEstudanteLocalidade(estudanteLocalidade);

            return Task.FromResult(estudanteLocalidade);
        }
    }
}
