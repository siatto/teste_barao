using api.Domain.Models;

namespace api.Infra.Repositories.Interfaces
{
    public interface IUsuarioRepository
    {
        public void AtualizarUsuario(UsuarioModel usuario);
        void ExcluirUsuario(Guid id);
        List<UsuarioModel> ListarTodos();
        void SalvarUsuario(UsuarioModel usuario);
        UsuarioModel? UsuarioPorId(Guid id);
        UsuarioModel? UsuarioPorLogin(string login);
    }
}