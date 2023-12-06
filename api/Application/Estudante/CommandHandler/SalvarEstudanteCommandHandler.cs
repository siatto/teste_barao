using api.Application.Estudante.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Estudante.CommandHandler
{
    public class SalvarEstudanteCommandHandler : IRequestHandler<SalvarEstudanteCommand, EstudanteModel>
    {
        private readonly IEstudanteService _estudanteService;
        private readonly IValidator<SalvarEstudanteCommand> _estudanteValidator;

        public SalvarEstudanteCommandHandler(IEstudanteService estudanteService, IValidator<SalvarEstudanteCommand> estudanteValidator)
        {
            _estudanteService = estudanteService;
            _estudanteValidator = estudanteValidator;
        }

        public Task<EstudanteModel> Handle(SalvarEstudanteCommand request, CancellationToken cancellationToken)
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

            _estudanteService.SalvarEstudante(estudante);

            return Task.FromResult(estudante);
        }
    }
}
