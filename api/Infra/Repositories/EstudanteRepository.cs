using api.Domain.Models;
using api.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Infra.Repositories
{
    public class EstudanteRepository : IEstudanteRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<EstudanteRepository> _logger;

        public EstudanteRepository(Contexto contexto, ILogger<EstudanteRepository> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        public void AtualizarEstudante(EstudanteModel estudante)
        {
            try
            {
                _contexto.Estudante.Update(estudante);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao atualizar estudante: {ex.Message}");
                throw;
            }
        }

        public void ExcluirEstudante(Guid id)
        {
            try
            {
                EstudanteModel estudante = _contexto.Estudante.Find(id);

                if (estudante == null)
                    return;

                _contexto.Remove(estudante);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir estudante: {ex.Message}");
                throw;
            }
        }

        public List<EstudanteModel> ListarTodos()
        {
            try
            {
                return _contexto.Estudante.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar estudantes: {ex.Message}");
                throw;
            }
        }

        public void SalvarEstudante(EstudanteModel estudante)
        {
            try
            {
                _contexto.Estudante.Add(estudante);

                if (estudante.Localidade != null)
                {
                    _contexto.Localidade.Add(estudante.Localidade);
                    _contexto.EstudanteLocalidade.Add(new EstudanteLocalidadeModel
                    {
                        EstudanteId = estudante.Id,
                        LocalidadeId = estudante.Localidade.Id
                    });
                }

                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao salvar estudante: {ex.Message}");
                throw;
            }
        }

        public EstudanteModel? EstudantePorId(Guid id)
        {
            try
            {
                EstudanteModel estudante = _contexto.Estudante.Find(id);

                if (estudante == null)
                    return null;

                return estudante;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar estudante por ID: {ex.Message}");
                throw;
            }
        }

        public List<EstudanteModel> EstudantePorNome(string nome)
        {
            try
            {
                return _contexto.Estudante
                    .Where(estudante => estudante.NomeCompleto.Contains(nome))
                    .ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar estudantes por nome: {ex.Message}");
                throw;
            }
        }
    }
}