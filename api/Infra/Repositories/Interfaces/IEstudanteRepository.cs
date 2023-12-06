using api.Domain.Models;

namespace api.Infra.Repositories.Interfaces
{
    public interface IEstudanteRepository
    {
        void AtualizarEstudante(EstudanteModel estudante);
        void ExcluirEstudante(Guid id);
        List<EstudanteModel> ListarTodos();
        void SalvarEstudante(EstudanteModel estudante);
        EstudanteModel? EstudantePorId(Guid id);
        List<EstudanteModel> EstudantePorNome(string nome);
    }
}