using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class SalvarLocalidadeCommandHandler : IRequestHandler<SalvarLocalidadeCommand, LocalidadeModel>
    {
        private readonly ILocalidadeService _localidadeService;
        private readonly IValidator<SalvarLocalidadeCommand> _localidadeValidator;

        public SalvarLocalidadeCommandHandler(ILocalidadeService LocalidadeService, IValidator<SalvarLocalidadeCommand> LocalidadeValidator)
        {
            _localidadeService = LocalidadeService;
            _localidadeValidator = LocalidadeValidator;
        }

        public Task<LocalidadeModel> Handle(SalvarLocalidadeCommand request, CancellationToken cancellationToken)
        {
            var commandValidado = _localidadeValidator.Validate(request);

            if (!commandValidado.IsValid)
            {
                throw new ValidationException(commandValidado.Errors);
            }

            var localidade = new LocalidadeModel
            {
                Id = request.Id,
                Cep = request.Cep,
                Cidade = request.Cidade,
                Estado = request.Estado,
                Logradouro = request.Logradouro
            };

            _localidadeService.SalvarLocalidade(localidade);

            return Task.FromResult(localidade);
        }
    }
}
