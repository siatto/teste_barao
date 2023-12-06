using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories;
using Microsoft.Extensions.Logging;

namespace api.Domain.Services
{
    public class EstudanteLocalidadeService : IEstudanteLocalidadeService
    {
        private readonly EstudanteLocalidadeRepository _repository;
        private readonly ILogger<EstudanteLocalidadeService> _logger;

        public EstudanteLocalidadeService(EstudanteLocalidadeRepository repository, ILogger<EstudanteLocalidadeService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void AtualizarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade)
        {
            try
            {
                _repository.AtualizarEstudanteLocalidade(estudanteLocalidade);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar estudante localidade.");
                throw;
            }
        }

        public void ExcluirEstudanteLocalidade(Guid id)
        {
            try
            {
                _repository.ExcluirEstudanteLocalidade(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir estudante localidade.");
                throw;
            }
        }

        public List<EstudanteLocalidadeModel> ListarTodos()
        {
            try
            {
                return _repository.ListarTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todos os estudantes localidades.");
                throw;
            }
        }

        public void SalvarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade)
        {
            try
            {
                _repository.SalvarEstudanteLocalidade(estudanteLocalidade);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar estudante localidade.");
                throw;
            }
        }

        public EstudanteLocalidadeModel? EstudanteLocalidadePorId(Guid id)
        {
            try
            {
                return _repository.EstudanteLocalidadePorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter estudante localidade por ID.");
                throw;
            }
        }

        public EstudanteLocalidadeModel? EstudanteLocalidadePorEstudante(Guid estudanteId)
        {
            try
            {
                return _repository.EstudanteLocalidadePorEstudante(estudanteId);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter estudante localidade por estudante ID.");
                throw;
            }
        }
    }
}