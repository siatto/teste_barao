using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories;
using Microsoft.Extensions.Logging;

namespace api.Domain.Services
{
    public class LocalidadeService : ILocalidadeService
    {
        private readonly LocalidadeRepository _repository;
        private readonly ILogger<LocalidadeService> _logger;

        public LocalidadeService(LocalidadeRepository repository, ILogger<LocalidadeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void AtualizarLocalidade(LocalidadeModel localidade)
        {
            try
            {
                _repository.AtualizarLocalidade(localidade);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar localidade.");
                throw;
            }
        }

        public void ExcluirLocalidade(Guid id)
        {
            try
            {
                _repository.ExcluirLocalidade(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir localidade.");
                throw;
            }
        }

        public List<LocalidadeModel> ListarTodos()
        {
            try
            {
                return _repository.ListarTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todas as localidades.");
                throw;
            }
        }

        public void SalvarLocalidade(LocalidadeModel localidade)
        {
            try
            {
                _repository.SalvarLocalidade(localidade);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar localidade.");
                throw;
            }
        }

        public LocalidadeModel? LocalidadePorId(Guid id)
        {
            try
            {
                return _repository.LocalidadePorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter localidade por ID.");
                throw;
            }
        }

        public List<LocalidadeModel> LocalidadePorLogradouro(string logradouro)
        {
            try
            {
                return _repository.LocalidadePorLogradouro(logradouro);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter localidade por logradouro.");
                throw;
            }
        }
    }
}