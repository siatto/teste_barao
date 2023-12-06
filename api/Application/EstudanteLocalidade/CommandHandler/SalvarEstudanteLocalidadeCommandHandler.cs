using api.Application.EstudanteLocalidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.EstudanteLocalidade.CommandHandler
{
    public class SalvarEstudanteLocalidadeCommandHandler : IRequestHandler<SalvarEstudanteLocalidadeCommand, EstudanteLocalidadeModel>
    {
        private readonly IEstudanteLocalidadeService _estudanteLocalidadeService;
        private readonly IValidator<SalvarEstudanteLocalidadeCommand> _estudanteLocalidadeValidator;

        public SalvarEstudanteLocalidadeCommandHandler(IEstudanteLocalidadeService estudanteLocalidadeService, IValidator<SalvarEstudanteLocalidadeCommand> estudanteLocalidadeValidator)
        {
            _estudanteLocalidadeService = estudanteLocalidadeService;
            _estudanteLocalidadeValidator = estudanteLocalidadeValidator;
        }

        public Task<EstudanteLocalidadeModel> Handle(SalvarEstudanteLocalidadeCommand request, CancellationToken cancellationToken)
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

            _estudanteLocalidadeService.SalvarEstudanteLocalidade(estudanteLocalidade);

            return Task.FromResult(estudanteLocalidade);
        }
    }
}
