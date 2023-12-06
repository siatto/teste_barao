using api.Domain.Models;

namespace api.Domain.Services.Interfaces
{
    public interface IEstudanteService
    {
        List<EstudanteModel> ListarTodos();
        EstudanteModel? EstudantePorId(Guid id);
        List<EstudanteModel> EstudantePorNome(string nome);
        void SalvarEstudante(EstudanteModel estudante);
        void AtualizarEstudante(EstudanteModel estudante);
        void ExcluirEstudante(Guid id);
    }
}