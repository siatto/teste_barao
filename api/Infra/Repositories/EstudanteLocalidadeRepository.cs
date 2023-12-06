using api.Domain.Models;
using api.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Infra.Repositories
{
    public class EstudanteLocalidadeRepository : IEstudanteLocalidadeRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<EstudanteLocalidadeRepository> _logger;

        public EstudanteLocalidadeRepository(Contexto contexto, ILogger<EstudanteLocalidadeRepository> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        public void AtualizarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade)
        {
            try
            {
                _contexto.EstudanteLocalidade.Update(estudanteLocalidade);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao atualizar estudanteLocalidade: {ex.Message}");
                throw;
            }
        }

        public void ExcluirEstudanteLocalidade(Guid id)
        {
            try
            {
                EstudanteLocalidadeModel estudanteLocalidade = _contexto.EstudanteLocalidade.Find(id);

                if (estudanteLocalidade == null)
                    return;

                _contexto.Remove(estudanteLocalidade);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir estudanteLocalidade: {ex.Message}");
                throw;
            }
        }

        public List<EstudanteLocalidadeModel> ListarTodos()
        {
            try
            {
                return _contexto.EstudanteLocalidade.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar estudantesLocalidade: {ex.Message}");
                throw;
            }
        }

        public void SalvarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade)
        {
            try
            {
                _contexto.EstudanteLocalidade.Add(estudanteLocalidade);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao salvar estudanteLocalidade: {ex.Message}");
                throw;
            }
        }

        public EstudanteLocalidadeModel? EstudanteLocalidadePorId(Guid id)
        {
            try
            {
                EstudanteLocalidadeModel estudanteLocalidade = _contexto.EstudanteLocalidade.Find(id);

                if (estudanteLocalidade == null)
                    return null;

                return estudanteLocalidade;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar estudanteLocalidade por ID: {ex.Message}");
                throw;
            }
        }

        public EstudanteLocalidadeModel? EstudanteLocalidadePorEstudante(Guid estudanteId)
        {
            try
            {
                return _contexto.EstudanteLocalidade
                    .Include(m => m.Estudante)
                    .Include(m => m.Localidade)
                    .FirstOrDefault(x => x.EstudanteId == estudanteId);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar estudanteLocalidade por estudante: {ex.Message}");
                throw;
            }
        }
    }
}