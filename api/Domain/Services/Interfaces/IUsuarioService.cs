using api.Domain.Models;

namespace api.Domain.Services.Interfaces
{
    public interface IUsuarioService
    {
        List<UsuarioModel> ListarTodos();
        UsuarioModel? UsuarioPorId(Guid id);
        UsuarioModel UsuarioPorLoginSenha(string login, string senha);
        void SalvarUsuario(UsuarioModel usuario);
        void AtualizarUsuario(UsuarioModel usuario);
        void ExcluirUsuario(Guid id);
    }
}