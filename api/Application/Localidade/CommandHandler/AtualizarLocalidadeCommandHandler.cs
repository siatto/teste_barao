using api.Application.Localidade.Command;
using api.Domain.Models;
using api.Domain.Services.Interfaces;
using FluentValidation;
using MediatR;

namespace api.Application.Localidade.CommandHandler
{
    public class AtualizarLocalidadeCommandHandler : IRequestHandler<AtualizarLocalidadeCommand, LocalidadeModel>
    {
        private readonly ILocalidadeService _localidadeService;
        private readonly IValidator<AtualizarLocalidadeCommand> _localidadeValidator;

        public AtualizarLocalidadeCommandHandler(ILocalidadeService localidadeService, IValidator<AtualizarLocalidadeCommand> localidadeValidator)
        {
            _localidadeService = localidadeService;
            _localidadeValidator = localidadeValidator;
        }

        public Task<LocalidadeModel> Handle(AtualizarLocalidadeCommand request, CancellationToken cancellationToken)
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

            _localidadeService.AtualizarLocalidade(localidade);

            return Task.FromResult(localidade);
        }
    }
}
