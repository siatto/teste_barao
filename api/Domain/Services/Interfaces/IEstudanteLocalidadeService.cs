using api.Domain.Models;

namespace api.Domain.Services.Interfaces
{
    public interface IEstudanteLocalidadeService
    {
        List<EstudanteLocalidadeModel> ListarTodos();
        EstudanteLocalidadeModel? EstudanteLocalidadePorId(Guid id);
        EstudanteLocalidadeModel? EstudanteLocalidadePorEstudante(Guid estudanteId);
        void SalvarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade);
        void AtualizarEstudanteLocalidade(EstudanteLocalidadeModel estudanteLocalidade);
        void ExcluirEstudanteLocalidade(Guid id);
    }
}