using Microsoft.EntityFrameworkCore;

namespace api.Domain.Models
{
    public class Contexto : DbContext
    {
        public DbSet<UsuarioModel> Usuario { get; set; }
        public DbSet<EstudanteModel> Estudante { get; set; }
        public DbSet<LocalidadeModel> Localidade { get; set; }
        public DbSet<EstudanteLocalidadeModel> EstudanteLocalidade { get; set; }

        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes) { }
    }
}