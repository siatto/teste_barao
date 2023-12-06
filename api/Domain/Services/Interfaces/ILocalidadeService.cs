using api.Domain.Models;

namespace api.Domain.Services.Interfaces
{
    public interface ILocalidadeService
    {
        List<LocalidadeModel> ListarTodos();
        LocalidadeModel? LocalidadePorId(Guid id);
        List<LocalidadeModel> LocalidadePorLogradouro(string logradouro);
        void SalvarLocalidade(LocalidadeModel Localidade);
        void AtualizarLocalidade(LocalidadeModel Localidade);
        void ExcluirLocalidade(Guid id);
    }
}
