using api.Domain.Models;

namespace api.Infra.Repositories.Interfaces
{
    public interface IEstudanteLocalidadeRepository
    {
        void AtualizarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade);
        void ExcluirEstudanteLocalidade(Guid id);
        List<EstudanteLocalidadeModel> ListarTodos();
        void SalvarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade);
        EstudanteLocalidadeModel? EstudanteLocalidadePorId(Guid id);
        EstudanteLocalidadeModel? EstudanteLocalidadePorEstudante(Guid estudanteId);
    }
}