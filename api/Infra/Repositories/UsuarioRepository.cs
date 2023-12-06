using api.Domain.Models;
using api.Infra.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace api.Infra.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly Contexto _contexto;
        private readonly ILogger<UsuarioRepository> _logger;

        public UsuarioRepository(Contexto contexto, ILogger<UsuarioRepository> logger)
        {
            _contexto = contexto;
            _logger = logger;
        }

        public void AtualizarUsuario(UsuarioModel usuario)
        {
            try
            {
                _contexto.Usuario.Update(usuario);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao atualizar usuário: {ex.Message}");
                throw;
            }
        }

        public void ExcluirUsuario(Guid id)
        {
            try
            {
                UsuarioModel usuario = _contexto.Usuario.Find(id);

                if (usuario == null)
                    return;

                _contexto.Remove(usuario);
                _contexto.SaveChanges();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao excluir usuário: {ex.Message}");
                throw;
            }
        }

        public List<UsuarioModel> ListarTodos()
        {
            try
            {
                return _contexto.Usuario.ToList();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao listar usuários: {ex.Message}");
                throw;
            }
        }

        public void SalvarUsuario(UsuarioModel usuario)
        {
            try
            {
                _contexto.Usuario.Add(usuario);
                _contexto.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                _logger.LogError($"Erro ao salvar usuário: {ex.Message}");
                throw;
            }
        }

        public UsuarioModel? UsuarioPorId(Guid id)
        {
            try
            {
                UsuarioModel usuario = _contexto.Usuario.Find(id);

                if (usuario == null)
                    return null;

                return usuario;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar usuário por ID: {ex.Message}");
                throw;
            }
        }

        public UsuarioModel? UsuarioPorLogin(string login)
        {
            try
            {
                return _contexto.Usuario
                    .Where(u => u.Login == login)
                    .FirstOrDefault();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao buscar usuário por login: {ex.Message}");
                throw;
            }
        }
    }
}