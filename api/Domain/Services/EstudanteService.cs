using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories;
using Microsoft.Extensions.Logging;

namespace api.Domain.Services
{
    public class EstudanteService : IEstudanteService
    {
        private readonly EstudanteRepository _repository;
        private readonly ILogger<EstudanteService> _logger;

        public EstudanteService(EstudanteRepository repository, ILogger<EstudanteService> logger)
        {
            _repository = repository;
            _logger = logger;
        }

        public void AtualizarEstudante(EstudanteModel estudante)
        {
            try
            {
                _repository.AtualizarEstudante(estudante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar estudante.");
                throw;
            }
        }

        public void ExcluirEstudante(Guid id)
        {
            try
            {
                _repository.ExcluirEstudante(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir estudante.");
                throw;
            }
        }

        public List<EstudanteModel> ListarTodos()
        {
            try
            {
                return _repository.ListarTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todos os estudantes.");
                throw;
            }
        }

        public void SalvarEstudante(EstudanteModel estudante)
        {
            try
            {
                _repository.SalvarEstudante(estudante);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar estudante.");
                throw;
            }
        }

        public EstudanteModel? EstudantePorId(Guid id)
        {
            try
            {
                return _repository.EstudantePorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter estudante por ID.");
                throw;
            }
        }

        public List<EstudanteModel> EstudantePorNome(string nome)
        {
            try
            {
                return _repository.EstudantePorNome(nome);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter estudantes por nome.");
                throw;
            }
        }
    }
}