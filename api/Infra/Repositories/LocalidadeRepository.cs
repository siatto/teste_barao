using api.Domain.Models;
using api.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Infra.Repositories
{
    public class LocalidadeRepository : ILocalidadeRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<LocalidadeRepository> _logger;

        public LocalidadeRepository(Contexto contexto, ILogger<LocalidadeRepository> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        public void AtualizarLocalidade(LocalidadeModel localidade)
        {
            try
            {
                _contexto.Localidade.Update(localidade);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao atualizar localidade: {ex.Message}");
                throw;
            }
        }

        public void ExcluirLocalidade(Guid id)
        {
            try
            {
                LocalidadeModel localidade = _contexto.Localidade.Find(id);

                if (localidade == null)
                    return;

                _contexto.Remove(localidade);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir localidade: {ex.Message}");
                throw;
            }
        }

        public List<LocalidadeModel> ListarTodos()
        {
            try
            {
                return _contexto.Localidade.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar localidades: {ex.Message}");
                throw;
            }
        }

        public void SalvarLocalidade(LocalidadeModel localidade)
        {
            try
            {
                _contexto.Localidade.Add(localidade);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao salvar localidade: {ex.Message}");
                throw;
            }
        }

        public LocalidadeModel? LocalidadePorId(Guid id)
        {
            try
            {
                LocalidadeModel localidade = _contexto.Localidade.Find(id);

                if (localidade == null)
                    return null;

                return localidade;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar localidade por ID: {ex.Message}");
                throw;
            }
        }

        public List<LocalidadeModel> LocalidadePorLogradouro(string logradouro)
        {
            try
            {
                return _contexto.Localidade
                    .Where(localidade => localidade.Logradouro.Contains(logradouro))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar localidades por logradouro: {ex.Message}");
                throw;
            }
        }
    }
}