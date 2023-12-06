using api.Infra.Utility;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace api.Domain.Models
{
    [Table("Estudante")]
    public class EstudanteModel : BaseEntity
    {
        private string _nomeCompleto;

        [Required(ErrorMessage = "O campo Nome Completo é obrigatório.")]
        [RegularExpression(@"^[A-Za-zÀ-ÖØ-öø-ÿ]+(\s[A-Za-zÀ-ÖØ-öø-ÿ]+)+$", ErrorMessage = "O Nome Completo deve conter pelo menos dois trechos de nomes.")]
        public string NomeCompleto
        {
            get { return _nomeCompleto; }
            set { _nomeCompleto = value.ToUpper(); }
        }

        [Required(ErrorMessage = "O campo Data de Nascimento é obrigatório.")]
        [DataType(DataType.Date, ErrorMessage = "Formato de Data inválido.")]
        [ValidarIdadeAttr(18, ErrorMessage = "A idade mínima deve ser de 18 anos.")]
        public DateTime DataNascimento { get; set; }

        [NotMapped]
        public LocalidadeModel? Localidade { get; set; }
    }
}
