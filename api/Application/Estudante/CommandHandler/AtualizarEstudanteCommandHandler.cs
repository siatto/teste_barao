using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class AtualizarEstudanteCommandHandler : IRequestHandler<AtualizarEstudanteCommand, EstudanteModel>
    {
        private readonly IEstudanteService _estudanteService;
        private readonly IValidator<AtualizarEstudanteCommand> _estudanteValidator;

        public AtualizarEstudanteCommandHandler(IEstudanteService estudanteService, IValidator<AtualizarEstudanteCommand> estudanteValidator)
        {
            _estudanteService = estudanteService;
            _estudanteValidator = estudanteValidator;
        }

        public Task<EstudanteModel> Handle(AtualizarEstudanteCommand request, CancellationToken cancellationToken)
        {
            var commandValidado = _estudanteValidator.Validate(request);

            if (!commandValidado.IsValid)
            {
                throw new ValidationException(commandValidado.Errors);
            }

            var estudante = new EstudanteModel
            {
                Id = request.Id,
                NomeCompleto = request.NomeCompleto,
                DataNascimento = request.DataNascimento,
                Localidade = request.Localidade
            };

            _estudanteService.AtualizarEstudante(estudante);

            return Task.FromResult(estudante);
        }
    }
}
