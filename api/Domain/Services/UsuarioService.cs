using api.Domain.Models;
using api.Domain.Services.Interfaces;
using api.Infra.Repositories;
using Microsoft.Extensions.Logging;

namespace api.Domain.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly UsuarioRepository _repository;
        private readonly ISenhaHasher _passwordHasher;
        private readonly ILogger<UsuarioService> _logger;

        public UsuarioService(UsuarioRepository repository, ISenhaHasher passwordHasher, ILogger<UsuarioService> logger)
        {
            _repository = repository;
            _passwordHasher = passwordHasher;
            _logger = logger;
        }

        public void AtualizarUsuario(UsuarioModel usuario)
        {
            try
            {
                _repository.AtualizarUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao atualizar usuário");
                throw;
            }
        }

        public void ExcluirUsuario(Guid id)
        {
            try
            {
                _repository.ExcluirUsuario(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao excluir usuário");
                throw;
            }
        }

        public List<UsuarioModel> ListarTodos()
        {
            try
            {
                return _repository.ListarTodos();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao listar todos os usuários");
                throw;
            }
        }

        public void SalvarUsuario(UsuarioModel usuario)
        {
            try
            {
                usuario.Senha = _passwordHasher.HashSenha(usuario.Senha);
                _repository.SalvarUsuario(usuario);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao salvar usuário");
                throw;
            }
        }

        public UsuarioModel? UsuarioPorId(Guid id)
        {
            try
            {
                return _repository.UsuarioPorId(id);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter usuário por ID");
                throw;
            }
        }

        public UsuarioModel? UsuarioPorLoginSenha(string login, string senha)
        {
            try
            {
                var usuario = _repository.UsuarioPorLogin(login);

                if (usuario != null && _passwordHasher.ValidaSenha(usuario.Senha, senha))
                {
                    return usuario;
                }

                return null;
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Erro ao obter usuário por login e senha");
                throw;
            }
        }
    }
}