using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    public class EstudanteLocalidadeModel : BaseEntity
    {
        [BindRequired]
        public Guid EstudanteId { get; set; }
        [BindNever]
        public virtual EstudanteModel? Estudante { get; set; }
        [BindRequired]
        public Guid LocalidadeId { get; set; }
        [BindNever]
        public virtual LocalidadeModel? Localidade { get; set; }

    }
}
