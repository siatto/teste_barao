using api.Domain.Models;

namespace api.Infra.Repositories.Interfaces
{
    public interface ILocalidadeRepository
    {
        void AtualizarLocalidade(LocalidadeModel localidade);
        void ExcluirLocalidade(Guid id);
        List<LocalidadeModel> ListarTodos();
        void SalvarLocalidade(LocalidadeModel localidade);
        LocalidadeModel? LocalidadePorId(Guid id);
        List<LocalidadeModel> LocalidadePorLogradouro(string logradouro);
    }
}